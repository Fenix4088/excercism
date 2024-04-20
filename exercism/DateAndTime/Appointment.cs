namespace Exercism.Date;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        try
        {
            return DateTime.Parse(appointmentDateDescription);
        }
        catch (Exception e)
        {
            return DateTime.Now;
        }
    }

    public static bool HasPassed(DateTime appointmentDate) => appointmentDate < DateTime.Now;

    public static bool IsAfternoonAppointment(DateTime appointmentDate) =>
        appointmentDate.Hour is >= 12 and < 18;
    public static string Description(DateTime appointmentDate) => $"You have an appointment on {appointmentDate:M/d/yyyy h:mm:ss tt}.";

    public static DateTime AnniversaryDate()
    {
        return new DateTime(DateTime.Now.Year, 9, 15);
    }
}