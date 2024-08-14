using System.Text.RegularExpressions;
namespace Exercism.Strings;

public class ResistorColorTrio
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

    private static string  GetColorIndex(string color) => Array.IndexOf(_colors, color).ToString();
    public static string Label(string[] colors)
    {

        var trailingZeros = new string('0', Int32.Parse(GetColorIndex(colors[2])));
        var oms = (GetColorIndex(colors[0]) + GetColorIndex(colors[1]) + trailingZeros);
        var pattern = @"0{3}$";

        if (Regex.IsMatch(oms, pattern))
        {
            return Regex.Replace(oms, pattern, " kiloohms");
        }

        return oms + " ohms";
    }
}