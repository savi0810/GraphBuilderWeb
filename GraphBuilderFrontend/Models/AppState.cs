namespace GraphBuilderFrontend.Models;

    public class AppState
    {
        public string ErrorMessage { get; private set; } = string.Empty;

        public void SetError(string message)
        {
            ErrorMessage = message;
            Console.WriteLine($"Error: {message}");
        }

        public void ClearError() => ErrorMessage = string.Empty;
    }
