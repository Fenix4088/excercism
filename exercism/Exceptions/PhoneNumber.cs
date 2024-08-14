using System.Text.RegularExpressions;

namespace Exercism.Exceptions;

using System;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        var justNumbers = new string(phoneNumber.Where(char.IsNumber).Select(c => c).ToArray());

        var isMatch = Regex.IsMatch(justNumbers, @"^1?[2-9][0-9]{2}[2-9][0-9]{6}$");

        if(!isMatch) throw new ArgumentException();
        
        return justNumbers.Reverse().Aggregate("", (acc, num) =>
        {
            if (acc.Length < 10) acc = num + acc;
            return acc;
        });
    }
}