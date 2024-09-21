namespace Exercism.BethanyShop.Interfaces;

public interface IEmployee
{
    double ReceiveWage(bool resetHours = true);
    void GiveBonus();
    void PerformWork();
    void DisplayEmployeeDetails();
}