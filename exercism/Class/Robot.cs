namespace Exercism.Class;

public class Robot
{
    private string _name;
    private static HashSet<string> cache = new HashSet<string> {};

    public string Name => _name;
    
    public Robot()
    {
        var rand = new Random(); 
        this._name = GenerateName();
    }
    
    private string GenerateName()
    {
        var rand = new Random();
        var name = "";
        var wasAdded = false;
        while (!wasAdded)
        {
            name = $"{(char)rand.Next(65, 91)}{(char)rand.Next(65, 91)}{rand.Next(100, 999)}";
            wasAdded = cache.Add(name);
        }

        return name;
    }

    public void Reset()
    {
        this._name = GenerateName();
    }
}