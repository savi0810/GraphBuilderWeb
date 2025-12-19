using GraphBuilderShared.Models;

namespace GraphBuilderFrontend.Services
{
    public class FunctionManager
    {
        private readonly GraphApiService _apiService;
        private readonly ViewportManager _viewportManager;
        private readonly Dictionary<int, GraphFunction> _functions = new();
        private int _nextId = 1;

        public IReadOnlyCollection<GraphFunction> Functions => _functions.Values;
        public event Action? FunctionsChanged;

        public FunctionManager(GraphApiService apiService, ViewportManager viewportManager)
        {
            _apiService = apiService;
            _viewportManager = viewportManager;
            _viewportManager.ViewportChanged += async () => await RecalculateAllFunctions();
        }

        public async Task<(bool Success, string? Error)> AddFunctionAsync(string expression, string color)
        {
            try
            {
                var validation = await _apiService.ValidateExpressionAsync(expression);
                if (!validation.IsValid)
                    return (false, validation.ErrorMessage ?? "Invalid expression");

                var function = new GraphFunction
                {
                    Id = _nextId++,
                    Expression = expression,
                    Color = color,
                    Path = ""
                };

                _functions[function.Id] = function;
                await CalculateFunctionPoints(function);
                FunctionsChanged?.Invoke();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool Success, string? Error)> UpdateFunctionAsync(GraphFunction function, string newExpression)
        {
            try
            {
                var validation = await _apiService.ValidateExpressionAsync(newExpression);
                if (!validation.IsValid)
                    return (false, validation.ErrorMessage ?? "Invalid expression");

                function.Expression = newExpression;
                await CalculateFunctionPoints(function);
                FunctionsChanged?.Invoke();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task UpdateFunctionColorAsync(GraphFunction function, string newColor)
        {
            function.Color = newColor;
            FunctionsChanged?.Invoke();
            await Task.CompletedTask;
        }

        public bool RemoveFunction(int id)
        {
            var removed = _functions.Remove(id);
            if (removed) FunctionsChanged?.Invoke();
            return removed;
        }

        public async Task RecalculateAllFunctions()
        {
            foreach (var function in _functions.Values)
                await CalculateFunctionPoints(function);
            FunctionsChanged?.Invoke();
        }

        private async Task CalculateFunctionPoints(GraphFunction function)
        {
            var viewport = _viewportManager.GetCurrentViewport();
            var request = new GraphRequest
            {
                Function = function.Expression,
                FromX = viewport.MinX,
                ToX = viewport.MaxX,
                PointsCount = 200
            };

            var points = await _apiService.CalculateFunctionAsync(request);
            function.Path = ConvertPointsToPath(points, viewport);
        }

        private string ConvertPointsToPath(List<PointDTO> points, ViewportState viewport)
        {
            const int canvasWidth = 1000;
            const int canvasHeight = 1000;

            var pathParts = new List<string>();
            bool isFirstPoint = true;

            foreach (var point in points)
            {
                if (!double.IsNaN(point.Y) && double.IsFinite(point.Y))
                {
                    var screenX = canvasWidth * (point.X - viewport.MinX) / (viewport.MaxX - viewport.MinX);
                    var screenY = canvasHeight - (canvasHeight * (point.Y - viewport.MinY) / (viewport.MaxY - viewport.MinY));

                    if (isFirstPoint)
                    {
                        pathParts.Add($"M {FormatCoordinate(screenX)} {FormatCoordinate(screenY)}");
                        isFirstPoint = false;
                    }
                    else
                    {
                        pathParts.Add($"L {FormatCoordinate(screenX)} {FormatCoordinate(screenY)}");
                    }
                }
                else
                {
                    isFirstPoint = true;
                }
            }

            return pathParts.Count > 0 ? string.Join(" ", pathParts) : "";
        }

        private string FormatCoordinate(double coordinate)
        {
            return coordinate.ToString("0.###", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}