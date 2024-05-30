namespace Exercism.IfStattements;

public class Verse()
{
    
    public readonly string animal;
    private readonly string _exclamation;
    private readonly string _animalAction;
    private readonly string _verseEnd;

    public Verse(
        string animal, 
        string exclamation = "", 
        string animalAction = "", 
        string verseEnd = $"I don't know why she swallowed the fly. Perhaps she'll die."
        ) : this()
    {
        this.animal = animal;
        this._exclamation = exclamation;
        this._animalAction = animalAction;
        this._verseEnd = verseEnd;
    }
    
    public string GetVerseStart() => $"I know an old lady who swallowed a {this.animal}.\n";
    
    public string GetVerseEnd() => this._verseEnd;

    public string GetReason(string prevAnimal) => $"She swallowed the {this.animal} to catch the {prevAnimal}{(this._animalAction.Length > 0 ? $" {this._animalAction}" : ".")}\n";
    
    public string GetExclamation() => this._exclamation.Length > 0 ? this._exclamation  + "\n" : "";
}

public static class FoodChain
{
    private static readonly List<Verse> Verses = new()
    {
        new Verse("fly"),
        new Verse("spider", "It wriggled and jiggled and tickled inside her."),
        new Verse("bird", "How absurd to swallow a bird!", "that wriggled and jiggled and tickled inside her."),
        new Verse("cat", "Imagine that, to swallow a cat!"),
        new Verse("dog", "What a hog, to swallow a dog!"),
        new Verse("goat", "Just opened her throat and swallowed a goat!"),
        new Verse("cow", "I don't know how she swallowed a cow!"),
        new Verse("horse", verseEnd: "She's dead, of course!")
    };
    
    public static string Recite(int verseNumber) => Recite(verseNumber, verseNumber);

    public static string Recite(int startVerse, int endVerse)
    {
        var song = "";
        for (int i = startVerse - 1; i < endVerse; i++)
        {
            if (Verses[i].animal == "horse")
            {
                song += Verses[i].GetVerseStart();
                song += Verses[i].GetVerseEnd();
                continue;
            }

            song += Verses[i].GetVerseStart();
            song += Verses[i].GetExclamation();
            
            if (i - 1 >= 0)
            {
                song += Verses[i].GetReason(Verses[i - 1].animal);
            }

            var prevVerse = i - 1;
            var prevAnimal = i - 2;
            while (prevVerse >= 0 && prevAnimal >= 0)
            {
                song += Verses[prevVerse].GetReason(Verses[prevAnimal].animal);
                prevVerse--;
                prevAnimal--;
            }
            
            song += i == endVerse - 1 ? Verses[i].GetVerseEnd() : Verses[i].GetVerseEnd() + "\n\n";
        }

        return song;
    }
}