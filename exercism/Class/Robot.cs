namespace Exercism;

public class Robot
{
    public string Name
    {
        get
        {
            var rand = new Random(); 
            return $"{(char)rand.Next(65, 91)}{(char)rand.Next(65, 91)}{rand.Next(1000, 10000)}";
        }
    }

    public void Reset()
    {
        Console.WriteLine(Name);
    }
}