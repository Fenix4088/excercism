using Exercism.RegularExpressions;

var lp = new LogParser();
// Console.WriteLine(lp.ListLinesWithPasswords(new string[] {"my passwordsecret is great"}));
// => "passwordsecret: my passwordsecret is great"


Console.WriteLine(lp.ListLinesWithPasswords(lp.ListLinesWithPasswords(new string[] {"my password secret"})));
// => {"--------: my password secret"}