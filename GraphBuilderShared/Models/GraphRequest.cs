namespace GraphBuilderShared.Models;

    public class GraphRequest
    {
        public string Function { get; set; } = string.Empty;
        public double FromX { get; set; }
        public double ToX { get; set; }
        public int PointsCount { get; set; } = 100;
    }
