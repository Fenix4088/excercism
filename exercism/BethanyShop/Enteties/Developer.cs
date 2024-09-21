namespace Exercism.BethanyShop.Enteties;

public class Developer(string firstName, string lastName, string email, DateTime birthDate, double? hourlyRate)
    : Employee(firstName, lastName, email, birthDate, hourlyRate)
{
    public string CurrentProject { get; set; }
};