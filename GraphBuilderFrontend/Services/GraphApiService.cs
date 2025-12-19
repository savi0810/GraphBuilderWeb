using GraphBuilderShared.Models;
using System.Net.Http.Json;

namespace GraphBuilderFrontend.Services
{
    public class GraphApiService 
    {
        private readonly HttpClient _httpClient;

        public GraphApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PointDTO>> CalculateFunctionAsync(GraphRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/graph/calculate", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<PointDTO>>()
                ?? throw new InvalidOperationException("Failed to parse response");
        }

        public async Task<ValidationResult> ValidateExpressionAsync(string expression)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(expression))
                    return new ValidationResult
                    {
                        IsValid = false,
                        ErrorMessage = "Expression cannot be empty"
                    };

                var response = await _httpClient.PostAsJsonAsync("api/graph/validate", expression);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return new ValidationResult
                    {
                        IsValid = false,
                        ErrorMessage = $"Validation error: {response.StatusCode} - {errorContent}"
                    };
                }

                return await response.Content.ReadFromJsonAsync<ValidationResult>()
                    ?? new ValidationResult { IsValid = false, ErrorMessage = "Failed to parse validation response" };
            }
            catch (HttpRequestException ex)
            {
                return new ValidationResult
                {
                    IsValid = false,
                    ErrorMessage = $"Network error: {ex.Message}"
                };
            }
        }
    }
}