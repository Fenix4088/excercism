
using Exercism.OperatorOverloading;

CurrencyAmount amountA = new CurrencyAmount(55, "HD");
// amountA > new CurrencyAmount(50, "HD")
// => true
// amountA < new CurrencyAmount(50, "HD")
// => false
// amountA > new CurrencyAmount(50, "USD")

Console.WriteLine(amountA < new CurrencyAmount(50, "USD"));