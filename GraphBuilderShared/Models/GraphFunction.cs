namespace GraphBuilderShared.Models;

public class GraphFunction
{
    public int Id { get; set; }
    public string Expression { get; set; } = "";
    public string Color { get; set; } = "#000000";
    public string Path { get; set; } = "";
}
