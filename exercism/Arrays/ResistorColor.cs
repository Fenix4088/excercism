namespace Exercism.Arrays;

enum Color
{
    Black,
    Brown,
    Red,
    Orange,
    Yellow,
    Green,
    Blue,
    Violet,
    Grey,
    White
}

public static class ResistorColor
{
    public static string Capitilize(this string str)
    {
        if (string.IsNullOrEmpty(str)) return str;
        return $"{str[..1].ToUpper()}{str[1..]}";
    }

    public static int ColorCode(string color)
    {
        var colorsArr = Enum.GetNames(typeof(Color));

        var res = 0;
        
        for (var i = 0; i < colorsArr.Length; i++)
        {
            if (color == colorsArr[i].ToLower())
            {
                res = i;
                break;
            }
        }
        return res;
    }

    public static string[] Colors() => Enum.GetNames(typeof(Color)).Select(color => color.ToLower()).ToArray();
}