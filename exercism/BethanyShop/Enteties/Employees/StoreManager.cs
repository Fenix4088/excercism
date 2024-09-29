namespace Exercism.BethanyShop.Enteties;

public class StoreManager(string firstName, string lastName, string email, DateTime birthDate, double? hourlyRate)
    : Employee(firstName, lastName, email, birthDate, hourlyRate)
{
};