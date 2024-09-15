using BethanysPieShopHRM.Logic;
using Newtonsoft.Json;

namespace Exercism.BethanyShop.Enteties;

public class Employee
{
    public string firstName;
    public string lastName;
    public string email;
    public DateTime birthDate;
    
    public int numberOfHoursWorked;
    public double wage;
    public double? hourlyRate;
    public EmployeeType employeeType;

    public static double taxtRate = 0.15;
    
    const int minHoursWorkingUnit = 1;
    
    public Employee(
        string firstName, 
        string lastName, 
        string email, 
        DateTime birthDate, 
        double? hourlyRate, 
        EmployeeType employeeType = EmployeeType.StoreManager)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.email = email;
        this.birthDate = birthDate;
        this.hourlyRate = hourlyRate ?? 10;
        this.employeeType = employeeType;
    }

    public void PerformWork()
    {
        PerformWork(minHoursWorkingUnit);
    }

    public void PerformWork(int numberOfHours)
    {
        numberOfHoursWorked += numberOfHours;
        Console.WriteLine($"{firstName} {lastName} has worked for {numberOfHoursWorked}");
    }

    public string ConvertToJson() => JsonConvert.SerializeObject(this);

    public int CalculateBonus(int bonus, ref int bonusTax)
    {

        if (numberOfHoursWorked > 10) bonus *= 2;

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

        return wageCalculations.ComplexWageCalculation(wage, taxtRate, 3, 42);
    }

    public double ReceiveWage(bool resetHours = true)
    {
        double wageBeforeTax = 0.0;

        
        if (employeeType == EmployeeType.Manager)
        {
            wageBeforeTax = numberOfHoursWorked * hourlyRate.Value * 1.25;
            Console.WriteLine($"An extra was added to the wage sinse {firstName} is a manager!.");
        }
        else
        {
            wageBeforeTax = numberOfHoursWorked * hourlyRate.Value;
        }

        double taxAmount = wageBeforeTax * taxtRate;
        wage = wageBeforeTax - taxAmount;

        Console.WriteLine($"{firstName} {lastName} has received a wage of {wage} for {numberOfHoursWorked} hour(s) of work.");

        if (resetHours) numberOfHoursWorked = 0;
        
        return wage;
    }

    public static void DisplayTaxRate()
    {
        Console.WriteLine($"The current tax rate is {taxtRate}");
    }

    public void DisplayEmployeeDetails()
    {
        Console.WriteLine($"\nFirst name: \t{firstName}\nLast name: \t{lastName}\nEmail: \t{email}\nBirthday: \t{birthDate.ToShortDateString()}\nTax rate: \t{taxtRate}");
    }
}