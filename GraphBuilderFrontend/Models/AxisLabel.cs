namespace GraphBuilderFrontend.Models;

public enum AxisLabelType
{
    X,
    Y,
    Zero
}

public class AxisLabel
{
    public double X { get; set; }
    public double Y { get; set; }
    public string Value { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public AxisLabelType Type { get; set; }
}

