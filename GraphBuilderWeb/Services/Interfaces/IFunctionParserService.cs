using GraphBuilderShared.Models;

namespace GraphBuilderWeb.Services.Interfaces;

public interface IFunctionParserService
{
    Task<ValidationResult> ValidateExpressionAsync(string expression);
}
