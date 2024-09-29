namespace Exercism.BethanyShop.Enteties;

public class Researcher(string firstName, string lastName, string email, DateTime birthDate, double? hourlyRate)
    : Employee(firstName, lastName, email, birthDate, hourlyRate)
{
    public int NumberOfPieTastedInvented { get; private set; } = 7;

    public void ResearchNewPieTastes(int researchHours)
    {
        NumberOfHoursWorked += researchHours;

        if (new Random().Next(100) > 50)
        {
            NumberOfPieTastedInvented++;
            Console.WriteLine($"Researcher {FirstName} {LastName} has invented a new pie taste! Total number of pies invented: {NumberOfPieTastedInvented}");
        }
        else
        {
            Console.WriteLine($"Researcher {FirstName} {LastName} is working still on a new pie taste!");

        }
    }
};