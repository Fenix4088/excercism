namespace Exercism.Enums;
using System;

using System;
using System.Collections.Generic;

public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    private readonly int mask;

    public Allergies(int mask)
    {
        this.mask = mask;
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        return (mask & (int)allergen) != 0;
    }

    public Allergen[] List()
    {
        var allergens = new List<Allergen>();

        foreach (Allergen allergen in Enum.GetValues(typeof(Allergen)))
        {
            if (IsAllergicTo(allergen))
            {
                allergens.Add(allergen);
            }
        }

        return allergens.ToArray();
    }
}
