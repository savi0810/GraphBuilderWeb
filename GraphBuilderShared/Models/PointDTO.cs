namespace GraphBuilderShared.Models;

public class PointDTO
{
    public double X { get; set; }
    public double Y { get; set; }
}

public class ValidationResult
{
    public bool IsValid { get; set; }
    public string? ErrorMessage { get; set; }
}