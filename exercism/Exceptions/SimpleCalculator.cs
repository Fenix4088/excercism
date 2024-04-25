namespace Exercism.Exceptions;

public static class SimpleOperation
{
    public static int Division(int operand1, int operand2)
    {
        return operand1 / operand2;
    }

    public static int Multiplication(int operand1, int operand2)
    {
        return operand1 * operand2;
    }

    public static int Addition(int operand1, int operand2)
    {
        return operand1 + operand2;
    }
}

public class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string operation)
    {
        try
        {
            if (operation == null)
            {
                throw new ArgumentNullException();
            }
        
        
            if (operation == "")
            {
                throw new ArgumentException();
            }


            return operation switch
            {
                "/" => $"{operand1} {operation} {operand2} = {SimpleOperation.Division(operand1, operand2)}",
                "*" => $"{operand1} {operation} {operand2} = {SimpleOperation.Multiplication(operand1, operand2)}",
                "+" => $"{operand1} {operation} {operand2} = {SimpleOperation.Addition(operand1, operand2)}",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        catch (DivideByZeroException e)
        {
            return "Division by zero is not allowed.";
        }
        
    }
}