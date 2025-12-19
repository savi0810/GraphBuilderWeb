using GraphBuilderFrontend.Models;

namespace GraphBuilderFrontend.Services.EventHandlers
{
    public class ViewportEventHandlers
    {
        private readonly ViewportManager _viewport;
        private readonly FunctionManager _functions;
        private readonly AppState _appState;

        public ViewportEventHandlers(
            ViewportManager viewport,
            FunctionManager functions,
            AppState appState)
        {
            _viewport = viewport;
            _functions = functions;
            _appState = appState;
        }

        public async Task HandleZoomIn()
        {
            try
            {
                _viewport.ZoomIn();
                await _functions.RecalculateAllFunctions();
            }
            catch (Exception ex)
            {
                _appState.SetError($"Ошибка увеличения: {ex.Message}");
            }
        }

        public async Task HandleZoomOut()
        {
            try
            {
                _viewport.ZoomOut();
                await _functions.RecalculateAllFunctions();
            }
            catch (Exception ex)
            {
                _appState.SetError($"Ошибка уменьшения: {ex.Message}");
            }
        }

        public async Task HandleResetView()
        {
            try
            {
                _viewport.Reset();
                await _functions.RecalculateAllFunctions();
            }
            catch (Exception ex)
            {
                _appState.SetError($"Ошибка сброса: {ex.Message}");
            }
        }
    }
}