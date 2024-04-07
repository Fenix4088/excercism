namespace Exercism;

public class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {

        if (balance >= 0 && balance < 1000) return 0.5f;
        else if (balance >= 1000 && balance < 5000) return 1.621f;
        else if (balance >= 5000) return 2.475f;
        else return 3.213f;
    }

    public static decimal Interest(decimal balance) => ((decimal)SavingsAccount.InterestRate(balance) * balance) / 100;

    public static decimal AnnualBalanceUpdate(decimal balance) => SavingsAccount.Interest(balance) + balance;

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        var count = 1;
        var updatedBalance = SavingsAccount.AnnualBalanceUpdate(balance);

        do
        {
            updatedBalance = SavingsAccount.AnnualBalanceUpdate(updatedBalance);
            count++;
        } while (targetBalance > updatedBalance);
        
        return count;
    }
}