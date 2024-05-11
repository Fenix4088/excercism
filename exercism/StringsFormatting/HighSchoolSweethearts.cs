using System.Globalization;

namespace Exercism.StringsFormatting;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB) => $"{studentA}\u2661{studentB}";

    public static string DisplayBanner(string studentA, string studentB) => $@"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {studentA}  +  {studentB}     **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
";

    public static string DisplayGermanExchangeStudents(string studentA
      , string studentB, DateTime start, float hours) =>
      $"{studentA} and {studentB} have been dating since {start:dd.MM.yyyy} - that's {hours.ToString("N2", new CultureInfo("de-DE"))} hours";
}