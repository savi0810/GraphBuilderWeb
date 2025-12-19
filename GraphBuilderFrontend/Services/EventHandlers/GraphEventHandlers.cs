using GraphBuilderFrontend.Models;
using GraphBuilderFrontend.Services;

namespace GraphBuilderFrontend.Services.EventHandlers
{
    public class GraphEventHandlers
    {
        private readonly ViewportManager _viewport;
        private readonly FunctionManager _functions;
        private readonly AppState _appState;

        public GraphEventHandlers(
            ViewportManager viewport,
            FunctionManager functions,
            AppState appState)
        {
            _viewport = viewport;
            _functions = functions;
            _appState = appState;
        }

        public async Task HandleWheel(double deltaY)
        {
            try
            {
                _viewport.ZoomWheel(deltaY);
                await _functions.RecalculateAllFunctions();
            }
            catch (Exception ex)
            {
                _appState.SetError($"Ошибка масштабирования: {ex.Message}");
            }
        }
    }
}