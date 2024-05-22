using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace Exercism.Strings;

public static class RotationalCipher
{
    private static string Plain = "abcdefghijklmnopqrstuvwxyz";
    
    public static string Rotate(string text, int shiftKey)
    {

        if (shiftKey == 0 || shiftKey == Plain.Length) return text;
        var cipher = "";
        
        for (int i = 0; i < text.Length; i++)
        {
            var letter = text[i];
            
            if (!char.IsLetter(letter))
            {
                cipher += letter;
                continue;
            }

            var isUpper = char.IsUpper(letter);
            
            var alphabetIndex = Plain.IndexOf(letter.ToString().ToLower());
            
            if (alphabetIndex == -1) continue;
            
            var cipherIndex = alphabetIndex + shiftKey;
            
            var newCharacter = cipherIndex >= Plain.Length ? Plain[cipherIndex - Plain.Length] : Plain[cipherIndex];

            cipher += isUpper ? newCharacter.ToString().ToUpper() : newCharacter;
        }
        return cipher;
    }
}