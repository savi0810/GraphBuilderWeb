using GraphBuilderWeb.Services.Interfaces;
using org.mariuszgromada.math.mxparser;
using GraphBuilderShared.Models;

namespace GraphBuilderWeb.Services;

public class FunctionParserService : IFunctionParserService
{
    public Task<ValidationResult> ValidateExpressionAsync(string expression)
    {
        try
        {
            var expr = new Expression(expression);
            expr.addArguments(new Argument("x"));
            expr.setSilentMode();

            bool isValid = expr.checkSyntax();

            return Task.FromResult(new ValidationResult
            {
                IsValid = isValid,
                ErrorMessage = isValid ? null : expr.getErrorMessage()
            });
        }
        catch
        {
            return Task.FromResult(new ValidationResult
            {
                IsValid = false,
                ErrorMessage = "Invalid expression"
            });
        }
    }
}