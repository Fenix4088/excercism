using System.Text.RegularExpressions;

namespace Exercism.IfStattements;

public static class Markdown
{
    private static bool IsHeader(string line) => line.StartsWith('#') && line[..7].Any(c => c != '#');
    private static bool IsListItem(string line) => line.StartsWith('*');
    private static string Wrap(string text, string tag) => $"<{tag}>{text}</{tag}>";
    
    private static string Parse(string line, string delimiter, string tag)
    {
        var pattern = $"{delimiter}(.+){delimiter}";
        var replacement = $"<{tag}>$1</{tag}>";
        return Regex.Replace(line, pattern, replacement);
    }

    private static string Parse__(string line) => Parse(line, "__", "strong");

    private static string Parse_(string line) => Parse(line, "_", "em");

    private static string ParseText(string line, bool list)
    {
        var parsedText = Parse_(Parse__((line)));

        if (list) return parsedText;

        return Wrap(parsedText, "p");
    }

    private static string ParseHeader(string line, ref bool inListAfter)
    {
        var count = 0;

        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] != '#') break;
            count += 1;
        }
        
        var headerTag = "h" + count;
        var headerHtml = Wrap(line.Substring(count + 1), headerTag);

        if (inListAfter)
        {
            inListAfter = false;
            return $"</ul>{headerHtml}";
        }
        inListAfter = false;
        return headerHtml;
    }

    private static string ParseListItem(string line, ref bool inListAfter)
    {
            var innerHtml = Wrap(ParseText(line.Substring(2), true), "li");

            if (inListAfter) return innerHtml;

            inListAfter = true;
            return $"<ul>{innerHtml}";
    }

    private static string ParseParagraph(string line, ref bool inListAfter)
    {
        if (!inListAfter) return ParseText(line, false);

        inListAfter = false;
        return $"</ul>{ParseText(line, false)}";
    }

    private static string ParseLine(string line, ref bool inListAfter) => line switch
    {
        var _line when IsHeader(_line) => ParseHeader(line, ref inListAfter),
        var _line when IsListItem(_line) => ParseListItem(line, ref inListAfter),
        _ => ParseParagraph(line, ref inListAfter)

    }; 
    public static string Parse(string line)
    {
        var lines = line.Split('\n');
        var result = "";
        var inListAfter = false;

        for (int i = 0; i < lines.Length; i++)
        {
            var lineResult = ParseLine(lines[i], ref inListAfter);
            result += lineResult;
        }

        if (inListAfter)
        {
            return result + "</ul>";
        }

        return result;
    }
}