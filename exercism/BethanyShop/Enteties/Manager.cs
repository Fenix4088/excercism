namespace Exercism.BethanyShop.Enteties;

public class Manager(string firstName, string lastName, string email, DateTime birthDate, double? hourlyRate)
    : Employee(firstName, lastName, email, birthDate, hourlyRate)
{

    public void AttendManagementMeeting()
    {
        NumberOfHoursWorked += 10;
        Console.WriteLine($"Manager {FirstName} {LastName} is now attending a long meeting that could have been an email!");
    }

    public override void GiveBonus()
    {
        if (NumberOfHoursWorked > 5)
        {
            Console.WriteLine($"Manager {FirstName} {LastName} received a management bonus of 500!");
        }
        else
        {
            Console.WriteLine($"Manager {FirstName} {LastName} received a management bonus of 250!");
        }
    }
}