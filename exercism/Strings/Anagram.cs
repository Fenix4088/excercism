namespace Exercism.Strings;

public class Anagram(string baseWord)
{
    private string baseWord = baseWord.ToLower();
    
    private static Dictionary<char, int> StringIntoDict(string str) => str.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());

    public string[] FindAnagrams(string[] potentialMatches)
    {

        var baseWordDict = StringIntoDict(this.baseWord);
        
        return potentialMatches.Where(potentialMatch =>
        {
            potentialMatch = potentialMatch.ToLower();
            if (potentialMatch.Length != this.baseWord.Length || potentialMatch == this.baseWord) return false;

            potentialMatch.GroupBy(c => c).ToDictionary(c => c.Key, c => c.Count());
            
            
            return StringIntoDict(potentialMatch).All(entry => baseWordDict.ContainsKey(entry.Key) && baseWordDict[entry.Key] == entry.Value);
        }).ToArray();
    }
}