namespace Exercism.BethanyShop.Enteties;

public class Employee
{
    public string firstName;
    public string lastName;
    public string email;
    public DateTime birthDay;
    
    public int numberOfHoursWorked;
    public double wage;
    public double hourlyRate;
    
    const int minHoursWorkingUnit = 1;

    public void PerformWork()
    {
        PerformWork(minHoursWorkingUnit);
    }

    public void PerformWork(int numberOfHours)
    {
        numberOfHoursWorked += numberOfHours;
        Console.WriteLine($"{firstName} {lastName} has worked for {numberOfHoursWorked}");
    }

    public double ReceiveWage(bool resetHours = true)
    {
        wage = numberOfHoursWorked * hourlyRate;
        Console.WriteLine($"{firstName} {lastName} has received a wage of {wage} for {numberOfHoursWorked} hour(s) of work.");

        if (resetHours) numberOfHoursWorked = 0;
        
        return wage;
    }
    
    public void DisplayEmployeeDetails()
    {
        Console.WriteLine($"\nFirst name: \t{firstName}\nLast name: \t{lastName}\nEmail: \t{email}\nBirthday: \t{birthDay.ToShortDateString()}\n");
    }
}