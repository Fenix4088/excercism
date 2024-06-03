namespace Exercism.Dictionaries;

using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    
    
    /* 
    public static IDictionary<char, int> Count(string sequence)
    {
        if (!sequence.All("ACGT".Contains))
            throw new ArgumentException();
        return (sequence + "ACGT").GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count() - 1);
    }
     */

    private static Dictionary<char, int> _DefaultNucleotides = new Dictionary<char, int>()
    {
        { 'A', 0 },
        { 'C', 0 },
        { 'G', 0 },
        { 'T', 0 },
    };

    private static bool IsDNAChain(string sequence) => sequence.Distinct().All(potentialNucleotide => _DefaultNucleotides.ContainsKey(potentialNucleotide));

    public static IDictionary<char, int> Count(string sequence)
    {
        
        if (!IsDNAChain(sequence)) throw new ArgumentException();

        var nucleoteds = new Dictionary<char, int>(_DefaultNucleotides);

        if (sequence.Equals(String.Empty)) return nucleoteds;

        return sequence.Aggregate(nucleoteds, (acc, next) =>
        {
            acc[next] += 1;
            return acc;
        });
    }
}