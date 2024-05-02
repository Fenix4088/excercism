



using Exercism.OptionalParameters;

var character = new Character();
character.Class = "Wizard";
character.Level = 4;
character.HitPoints = 28;

var destination = new Destination();
destination.Name = "Muros";
destination.Inhabitants = 732;


Console.WriteLine(GameMaster.Describe(character, destination));