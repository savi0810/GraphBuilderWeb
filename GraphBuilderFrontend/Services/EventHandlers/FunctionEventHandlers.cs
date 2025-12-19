using GraphBuilderFrontend.Models;
using GraphBuilderShared.Models;

namespace GraphBuilderFrontend.Services.EventHandlers
{
    public class FunctionEventHandlers
    {
        private readonly FunctionManager _functionManager;
        private readonly AppState _appState;

        public FunctionEventHandlers(FunctionManager functionManager, AppState appState)
        {
            _functionManager = functionManager;
            _appState = appState;
        }

        public async Task HandleAddFunction(string expression, string color)
        {
            try
            {
                var (success, error) = await _functionManager.AddFunctionAsync(expression, color);
                if (!success) _appState.SetError(error);
            }
            catch (Exception ex)
            {
                _appState.SetError($"Ошибка: {ex.Message}");
            }
        }

        public async Task HandleUpdateFunction(GraphFunction function, string newExpression)
        {
           var (success, error) = await _functionManager.UpdateFunctionAsync(function, newExpression);
        }

        public async Task HandleUpdateFunctionColor(GraphFunction function, string newColor)
        {
            try
            {
                await _functionManager.UpdateFunctionColorAsync(function, newColor);
            }
            catch (Exception ex)
            {
                _appState.SetError($"Ошибка: {ex.Message}");
            }
        }

        public void HandleRemoveFunction(GraphFunction function)
        {
            try
            {
                _functionManager.RemoveFunction(function.Id);
            }
            catch (Exception ex)
            {
                _appState.SetError($"Ошибка: {ex.Message}");
            }
        }
    }
}