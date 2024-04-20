// See https://aka.ms/new-console-template for mor

using Exercism.Date;
using Exercism.Inheritance;

var wizard = new Wizard();
Console.WriteLine(wizard.ToString());

var warrior = new Warrior();
Console.WriteLine(warrior.ToString());

// wizard.PrepareSpell();
Console.WriteLine(wizard.DamagePoints(warrior));
// => "Character is a Warrior"
