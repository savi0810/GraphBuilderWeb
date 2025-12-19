namespace GraphBuilderFrontend.Utils;

public static class ColorUtils
{
    private static readonly string[] _colors = new[]
    {
"#FF5252", "#FF4081", "#E040FB", "#7C4DFF", "#536DFE", "#448AFF",
        "#40C4FF", "#18FFFF", "#64FFDA", "#69F0AE", "#B2FF59", "#EEFF41",
        "#FFFF00", "#FFD740", "#FFAB40", "#FF6E40", "#FF3D00", "#FF1744",
        "#F50057", "#D500F9", "#651FFF", "#3D5AFE", "#2979FF", "#00B0FF",
        "#00E5FF", "#1DE9B6", "#00E676", "#76FF03", "#C6FF00", "#FFEA00",
        "#FFC400", "#FF9100", "#FF5722", "#E91E63", "#9C27B0", "#673AB7",
        "#3F51B5", "#2196F3", "#03A9F4", "#00BCD4", "#009688", "#4CAF50",
        "#8BC34A", "#CDDC39", "#FFEB3B", "#FFC107", "#FF9800", "#FF5722",
        "#795548", "#9E9E9E", "#607D8B", "#F44336", "#E91E63", "#9C27B0",
        "#673AB7", "#3F51B5", "#2196F3", "#03A9F4", "#00BCD4", "#009688",
        "#4CAF50", "#8BC34A", "#CDDC39", "#FFEB3B", "#FFC107", "#FF9800",
        "#FF5722", "#FF8A80", "#FF80AB", "#EA80FC", "#B388FF", "#8C9EFF",
        "#82B1FF", "#80D8FF", "#84FFFF", "#A7FFEB", "#B9F6CA", "#CCFF90",
        "#F4FF81", "#FFFF8D", "#FFE57F", "#FFD180", "#FF9E80", "#FF8A65",
        "#FF6E40", "#FF5252", "#FF4081", "#E040FB", "#7C4DFF", "#536DFE",
        "#448AFF", "#40C4FF", "#18FFFF", "#64FFDA", "#69F0AE", "#B2FF59",
        "#EEFF41", "#FFFF00", "#FFD740", "#FFAB40", "#FF6E40", "#FF3D00",
        "#FF1744", "#F50057", "#D500F9", "#651FFF", "#3D5AFE", "#2979FF",
        "#00B0FF", "#00E5FF", "#1DE9B6", "#00E676", "#76FF03", "#C6FF00",
        "#FFEA00", "#FFC400", "#FF9100", "#FF5722", "#E91E63", "#9C27B0",
        "#673AB7", "#3F51B5", "#2196F3", "#03A9F4", "#00BCD4", "#009688",
        "#4CAF50", "#8BC34A", "#CDDC39", "#FFEB3B", "#FFC107", "#FF9800",
        "#FF5722", "#795548", "#9E9E9E", "#607D8B", "#F44336", "#E91E63",
        "#9C27B0", "#673AB7", "#3F51B5", "#2196F3", "#03A9F4", "#00BCD4",
        "#009688", "#4CAF50", "#8BC34A", "#CDDC39", "#FFEB3B", "#FFC107",
        "#FF9800", "#FF5722", "#FF8A80", "#FF80AB", "#EA80FC", "#B388FF",
        "#8C9EFF", "#82B1FF", "#80D8FF", "#84FFFF", "#A7FFEB", "#B9F6CA",
        "#CCFF90", "#F4FF81", "#FFFF8D", "#FFE57F", "#FFD180", "#FF9E80",
        "#FF8A65", "#FF6E40", "#FF5252", "#FF4081", "#E040FB", "#7C4DFF",
        "#536DFE", "#448AFF", "#40C4FF", "#18FFFF", "#64FFDA", "#69F0AE",
        "#B2FF59", "#EEFF41", "#FFFF00", "#FFD740", "#FFAB40", "#FF6E40",
        "#FF3D00", "#FF1744", "#F50057", "#D500F9", "#651FFF", "#3D5AFE",
        "#2979FF", "#00B0FF", "#00E5FF", "#1DE9B6", "#00E676", "#76FF03",
        "#C6FF00", "#FFEA00", "#FFC400", "#FF9100", "#FF5722", "#E91E63",
        "#9C27B0", "#673AB7", "#3F51B5", "#2196F3", "#03A9F4", "#00BCD4",
        "#009688", "#4CAF50", "#8BC34A", "#CDDC39", "#FFEB3B", "#FFC107",
        "#FF9800", "#FF5722", "#795548", "#9E9E9E", "#607D8B", "#F44336",
        "#E91E63", "#9C27B0", "#673AB7", "#3F51B5", "#2196F3", "#03A9F4",
        "#00BCD4", "#009688", "#4CAF50", "#8BC34A", "#CDDC39", "#FFEB3B",
        "#FFC107", "#FF9800", "#FF5722", "#FF8A80", "#FF80AB", "#EA80FC",
        "#B388FF", "#8C9EFF", "#82B1FF", "#80D8FF", "#84FFFF", "#A7FFEB",
        "#B9F6CA", "#CCFF90", "#F4FF81", "#FFFF8D", "#FFE57F", "#FFD180",
        "#FF9E80", "#FF8A65", "#FF6E40"
    };

    public static string GetRandomColor() => _colors[Random.Shared.Next(_colors.Length)];
}