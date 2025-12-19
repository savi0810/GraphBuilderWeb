using GraphBuilderShared.Models;

namespace GraphBuilderWeb.Services.Interfaces;

public interface IGraphCalculationService
{
    Task<List<PointDTO>> CalculateFunctionAsync(
        string expression,
        double fromX,
        double toX,
        int pointsCount,
        CancellationToken cancellationToken = default);
}