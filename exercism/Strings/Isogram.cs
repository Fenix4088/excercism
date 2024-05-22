namespace Exercism.Strings;

using System;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        word = word.ToLower();
        return word.Where(char.IsLetter).Distinct().ToArray().Length == word.Where(char.IsLetter).ToArray().Length;
    }
}