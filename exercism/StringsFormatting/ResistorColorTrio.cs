namespace Exercism.StringsFormatting;

public static class ResistorColorTrio
{
    
    private static string[] _colors = new string[]
    {
        "black",
        "brown",
        "red",
        "orange",
        "yellow",
        "green",
        "blue",
        "violet",
        "grey",
        "white"
    };
    
    public static string Label(string[] colors)
    {
        var res = Array.IndexOf(_colors, colors[0]).ToString() + Array.IndexOf(_colors, colors[1]) +
                  Array.IndexOf(_colors, colors[2]);
        return res;
    }
}