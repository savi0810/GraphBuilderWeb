
using GraphBuilderShared.Models;

namespace GraphBuilderFrontend.Services
{
    public class ViewportManager
    {
        private ViewportState _viewport = new()
        {
            MinX = -10,
            MaxX = 10,
            MinY = -10,
            MaxY = 10
        };

        public ViewportState GetCurrentViewport() => _viewport;
        public event Action? ViewportChanged;

        public void ZoomIn()
        {
            if (_viewport.MaxX - _viewport.MinX > 0.2)
            {
                ZoomAroundCenter(0.8);
                ViewportChanged?.Invoke();
            }
        }

        public void ZoomOut()
        {
            if (_viewport.MaxX - _viewport.MinX < 2000)
            {
                ZoomAroundCenter(1.25);
                ViewportChanged?.Invoke();
            }
        }

        public void ZoomWheel(double deltaY)
        {
            var zoomFactor = deltaY > 0 ? 1.1 : 0.9;
            ZoomAroundCenter(zoomFactor);
        }

        private void ZoomAroundCenter(double factor)
        {
            var centerX = (_viewport.MinX + _viewport.MaxX) / 2;
            var centerY = (_viewport.MinY + _viewport.MaxY) / 2;

            var width = _viewport.MaxX - _viewport.MinX;
            var height = _viewport.MaxY - _viewport.MinY;

            var newWidth = width * factor;
            var newHeight = height * factor;

            _viewport.MinX = centerX - newWidth / 2;
            _viewport.MaxX = centerX + newWidth / 2;

            _viewport.MinY = centerY - newHeight / 2;
            _viewport.MaxY = centerY + newHeight / 2;
        }

        public void Reset()
        {
            _viewport = new ViewportState
            {
                MinX = -10,
                MaxX = 10,
                MinY = -10,
                MaxY = 10
            };
            ViewportChanged?.Invoke();
        }

        public bool CanZoomIn() => _viewport.MaxX - _viewport.MinX > 0.2;
        public bool CanZoomOut() => _viewport.MaxX - _viewport.MinX < 2000;
    }
}