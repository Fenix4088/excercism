using BethanysPieShopHRM.Logic;
using Exercism.Arrays;
using Newtonsoft.Json;

namespace Exercism.BethanyShop.Enteties;

public class Employee
{
    private string _firstName;
    private string _lastName;
    private string _email;
    private DateTime _birthDate;
    private int _numberOfHoursWorked;
    private double _wage;
    private double? _hourlyRate;
    private EmployeeType _employeeType;
    private static double _taxRate = 0.15;
    
    const int MinHoursWorkingUnit = 1;

    public string FirstName
    {
        get => _firstName;
        set => _firstName = value.Capitilize();
    }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public int NumberOfHoursWorked { get; private set; }
    public double Wage { get; private set; }
    public double? HourlyRate
    {
        get => _hourlyRate;
        set => _hourlyRate = _hourlyRate < 0 ? 0 : value;
    }
    public EmployeeType EmployeeType { get; set; }
    public static double TaxRate { get; set; }
    
    public Employee(
        string firstName, 
        string lastName, 
        string email, 
        DateTime birthDate, 
        double? hourlyRate, 
        EmployeeType employeeType = EmployeeType.StoreManager)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        BirthDate = birthDate;
        HourlyRate = hourlyRate ?? 10;
        EmployeeType = employeeType;
    }

    public void PerformWork()
    {
        PerformWork(MinHoursWorkingUnit);
    }

    public void PerformWork(int numberOfHours)
    {
        NumberOfHoursWorked += numberOfHours;
        Console.WriteLine($"{FirstName} {LastName} has worked for {NumberOfHoursWorked}");
    }

    public string ConvertToJson() => JsonConvert.SerializeObject(this);

    public int CalculateBonus(int bonus, ref int bonusTax)
    {

        if (NumberOfHoursWorked > 10) bonus *= 2;

        if (bonus >= 200)
        {
            bonusTax = bonus / 10;
            bonus -= bonusTax;
        }

        Console.WriteLine($"The employee got a bonus of {bonus}");
        return bonus;
        
    }

    public double CalculateWage()
    {
        WageCalculations wageCalculations = new WageCalculations();

        return wageCalculations.ComplexWageCalculation(Wage, TaxRate, 3, 42);
    }

    public double ReceiveWage(bool resetHours = true)
    {
        double wageBeforeTax = 0.0;

        
        if (EmployeeType == EmployeeType.Manager)
        {
            wageBeforeTax = NumberOfHoursWorked * HourlyRate.Value * 1.25;
            Console.WriteLine($"An extra was added to the wage sinse {FirstName} is a manager!.");
        }
        else
        {
            wageBeforeTax = NumberOfHoursWorked * HourlyRate.Value;
        }

        double taxAmount = wageBeforeTax * TaxRate;
        Wage = wageBeforeTax - taxAmount;

        Console.WriteLine($"{FirstName} {LastName} has received a wage of {Wage} for {NumberOfHoursWorked} hour(s) of work.");

        if (resetHours) NumberOfHoursWorked = 0;
        
        return Wage;
    }

    public static void DisplayTaxRate()
    {
        Console.WriteLine($"The current tax rate is {TaxRate}");
    }

    public void DisplayEmployeeDetails()
    {
        Console.WriteLine($"\nFirst name: \t{FirstName}\nLast name: \t{LastName}\nEmail: \t{Email}\nBirthday: \t{BirthDate.ToShortDateString()}\nTax rate: \t{TaxRate}");
    }
}