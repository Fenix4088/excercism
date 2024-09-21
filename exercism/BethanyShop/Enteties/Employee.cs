using BethanysPieShopHRM.Logic;
using Exercism.Arrays;
using Exercism.BethanyShop.Interfaces;
using Newtonsoft.Json;

namespace Exercism.BethanyShop.Enteties;

public class Employee(string firstName, 
    string lastName, 
    string email, 
    DateTime birthDate, 
    double? hourlyRate = 10): IEmployee
{
    const int MinHoursWorkingUnit = 1;
    public string FirstName
    {
        get => firstName;
        set => firstName = value.Capitilize();
    }
    public string LastName { get; set; } = lastName;
    public string Email { get; set; } = email;
    public DateTime BirthDate { get; set; } = birthDate;
    public int NumberOfHoursWorked { get; protected set; }
    public double Wage { get; private set; }
    public double? HourlyRate
    {
        get => hourlyRate;
        set => hourlyRate = hourlyRate < 0 ? 0 : value;
    }
    public static double TaxRate { get; set; } = 0.15;
    public Address Address { get; set; }

    public Employee(
        string firstName, 
        string lastName, 
        string email, 
        DateTime birthDate, 
        double? hourlyRate,
        string street,
        string houseNumber,
        string zipCode,
            string city
        ): this(firstName, lastName, email, birthDate, hourlyRate)
    {
        Address = new Address(street, houseNumber, zipCode, city);
    }

    public virtual void GiveBonus()
    {
        Console.WriteLine($"{FirstName} {LastName} received a generic bonus of 100!");
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
        double wageBeforeTax = NumberOfHoursWorked * HourlyRate.Value;
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