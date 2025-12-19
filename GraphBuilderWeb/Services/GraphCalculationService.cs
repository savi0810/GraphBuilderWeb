using GraphBuilderShared.Models;
using GraphBuilderWeb.Services.Interfaces;
using org.mariuszgromada.math.mxparser;

namespace GraphBuilderWeb.Services;

public class GraphCalculationService : IGraphCalculationService
{
    public async Task<List<PointDTO>> CalculateFunctionAsync(
        string expression,
        double fromX,
        double toX,
        int pointsCount,
        CancellationToken cancellationToken = default)
    {
        return await Task.Run(() =>
        {
            var points = new List<PointDTO>();

            Argument x = new Argument("x");

            Expression expr = new Expression(expression);
            expr.addArguments(x); 

            if (!expr.checkSyntax())
            {
                throw new InvalidOperationException(
                    $"Invalid expression: {expr.getErrorMessage()}");
            }

            double step = (toX - fromX) / Math.Max(pointsCount - 1, 1);

            for (int i = 0; i < pointsCount; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                double currentX = fromX + i * step;
                x.setArgumentValue(currentX);
                double y = expr.calculate();

                points.Add(new PointDTO
                {
                    X = Math.Round(currentX, 6),
                    Y = double.IsNaN(y) || double.IsInfinity(y)
                        ? double.NaN
                        : Math.Round(y, 6)
                });
            }

            return points;
        }, cancellationToken);
    }
}