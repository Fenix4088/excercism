namespace Exercism.Tuples;

public class PhoneNumber
{
    
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        var splitedPhone = phoneNumber.Split("-");
        return (splitedPhone[0] == "212", splitedPhone[1] == "555", splitedPhone[2]);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo) =>
        phoneNumberInfo.IsFake;

}