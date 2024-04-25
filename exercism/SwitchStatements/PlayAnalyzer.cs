namespace Exercism.SwitchStatements;

public class Manager
{
    public string Name { get; }

    public string? Club { get; }

    public Manager(string name, string? club)
    {
        this.Name = name;
        this.Club = club;
    }
    
}

public class Incident
{
    public virtual string GetDescription() => "An incident happened.";
}

public class Foul : Incident
{
    public override string GetDescription() => "The referee deemed a foul.";
}

public class Injury : Incident
{
    private readonly int player;

    public Injury(int player)
    {
        this.player = player;
    }

    public override string GetDescription() => $"Oh no! Player {player} is injured. Medics are on the field.";
}

public class PlayAnalyzer
{
    
    public static string AnalyzeOnField(int shirtNum)
    {
        return shirtNum switch
        {
            1 => "goalie",
            2 => "left back",
            3 or 4 => "center back",
            5 => "right back",
            6 or 7 or 8 => "midfielder",
            9 => "left wing",
            10 => "striker",
            _ when shirtNum is > 11 or < 0 => throw new ArgumentOutOfRangeException(),
            _ => "right wing"
        };
    }

    public static string AnalyzeOffField(object report)
    {
        return report switch
        {
            int i => $"There are {i} supporters at the match.",
            string s => s,
            Foul foul => foul.GetDescription(),
            Injury injury => injury.GetDescription(),
            Manager manager => $"{manager.Name}{(manager.Club != null ? $" ({manager.Club})" : string.Empty)}",
            _ => throw new ArgumentException()
        };
    }
    
}