
using GraphBuilderShared.Models;

namespace GraphBuilderFrontend.Utils
{
    public static class GeometryUtils
    {
        private const int CanvasSize = 1000;

        public static double WorldToScreenX(double worldX, ViewportState viewport)
        {
            return CanvasSize * (worldX - viewport.MinX) / (viewport.MaxX - viewport.MinX);
        }

        public static double WorldToScreenY(double worldY, ViewportState viewport)
        {
            return CanvasSize * (worldY - viewport.MinY) / (viewport.MaxY - viewport.MinY);
        }

        public static (List<GridLine> GridLines, AxisLine AxisX, AxisLine AxisY) CalculateGrid(ViewportState viewport)
        {
            var gridLines = new List<GridLine>();

            for (int x = (int)Math.Ceiling(viewport.MinX); x <= (int)Math.Floor(viewport.MaxX); x++)
            {
                if (x == 0) continue; 
                var screenX = WorldToScreenX(x, viewport);
                gridLines.Add(new GridLine(screenX, 0, screenX, CanvasSize));
            }

            for (int y = (int)Math.Ceiling(viewport.MinY); y <= (int)Math.Floor(viewport.MaxY); y++)
            {
                if (y == 0) continue; 
                var screenY = WorldToScreenY(y, viewport);
                gridLines.Add(new GridLine(0, screenY, CanvasSize, screenY));
            }

            var zeroX = WorldToScreenX(0, viewport);
            var zeroY = WorldToScreenY(0, viewport);
            var axisX = new AxisLine(0, zeroY, CanvasSize, zeroY);
            var axisY = new AxisLine(zeroX, 0, zeroX, CanvasSize);

            return (gridLines, axisX, axisY);
        }
    }

    public record GridLine(double X1, double Y1, double X2, double Y2);
    public record AxisLine(double X1, double Y1, double X2, double Y2);
}