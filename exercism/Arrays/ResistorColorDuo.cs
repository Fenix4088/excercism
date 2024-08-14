namespace Exercism.Arrays;

public static class ResistorColorDuo
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
    
    public static int Value(string[] colors) => int.Parse(Array.IndexOf(_colors, colors[0]).ToString() + Array.IndexOf(_colors, colors[1]).ToString());
}