namespace Exercism.OperatorOverloading;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;
    
    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    private static bool IsSameCurrency(string currencyA, string currencyB) => currencyA == currencyB;

    private static void CompareCurrency(string currencyA, string currencyB)
    {
        if (!IsSameCurrency(currencyA, currencyB)) throw new ArgumentException();
    }
    

    public static bool operator ==(CurrencyAmount curAmountA, CurrencyAmount curAmountB)
    {
        CompareCurrency(curAmountA.currency, curAmountB.currency);
        return curAmountA.amount == curAmountB.amount && curAmountA.currency == curAmountB.currency;
    }


    public static bool operator !=(CurrencyAmount curAmountA, CurrencyAmount curAmountB)
    {
        CompareCurrency(curAmountA.currency, curAmountB.currency);
        return curAmountA.amount != curAmountB.amount || curAmountA.currency != curAmountB.currency;
    }

    public static bool operator >(CurrencyAmount curAmountA, CurrencyAmount curAmountB)
    {
        CompareCurrency(curAmountA.currency, curAmountB.currency);
        return curAmountA.amount > curAmountB.amount;
    }
    
    public static bool operator <(CurrencyAmount curAmountA, CurrencyAmount curAmountB)
    {
        CompareCurrency(curAmountA.currency, curAmountB.currency);
        return curAmountA.amount < curAmountB.amount;
    }


    public static CurrencyAmount operator +(CurrencyAmount curAmountA, CurrencyAmount curAmountB)
    {
        CompareCurrency(curAmountA.currency, curAmountB.currency);
        return new CurrencyAmount(curAmountA.amount + curAmountB.amount, curAmountA.currency);
    }
    
    public static CurrencyAmount operator -(CurrencyAmount curAmountA, CurrencyAmount curAmountB)
    {
        CompareCurrency(curAmountA.currency, curAmountB.currency);
        return new CurrencyAmount(curAmountA.amount - curAmountB.amount, curAmountA.currency);

    }
    
    public static CurrencyAmount operator *(CurrencyAmount curAmountA, CurrencyAmount curAmountB)
    {
        CompareCurrency(curAmountA.currency, curAmountB.currency);
        return new CurrencyAmount(curAmountA.amount * curAmountB.amount, curAmountA.currency);
    }
    
    public static CurrencyAmount operator /(CurrencyAmount curAmountA, CurrencyAmount curAmountB)
    {
        CompareCurrency(curAmountA.currency, curAmountB.currency);
        return new CurrencyAmount(curAmountA.amount / curAmountB.amount, curAmountA.currency);
    }

    public static explicit operator double(CurrencyAmount currencyAmount) => (double)currencyAmount.amount;

    public static implicit operator decimal(CurrencyAmount currencyAmount) => currencyAmount.amount;

}