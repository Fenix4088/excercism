namespace Exercism.Date;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup(int month, int year)
{
    
    private int DaysUntilNext(DayOfWeek currentDay, DayOfWeek targetDay)
    {
        int daysUntil = ((int)targetDay - (int)currentDay + 7) % 7;
        return daysUntil == 0 ? 7 : daysUntil;
    }
    
    private List<DateTime> GetAllWeekDaysOfTheMonth(DayOfWeek dayOfWeek)
    {
        DateTime firstDay = new DateTime(year, month, 1);
        
        DateTime firstSelectedWeekDateOfMonth = new DateTime(year, month, 1 + DaysUntilNext(firstDay.DayOfWeek, dayOfWeek));

        List<DateTime> result = new List<DateTime>{};

        result.Add(firstSelectedWeekDateOfMonth);
        
        for (int i = 1; i < 5; i++)
        {
            DateTime currentDate = result[i - 1].AddDays(7);
            if (currentDate.Month == firstDay.Month)
            {
                result.Add(result[i - 1].AddDays(7));
            }

        }
        return result;
    }


    private DateTime GetMeetUpDate(List<DateTime> datesList, Schedule schedule)
    {
        foreach (var dateTime in datesList)
        {
            Console.WriteLine(dateTime.DayOfWeek);
        }

        switch (schedule)
        {
            case Schedule.Teenth:
                return datesList.First(dateTime => dateTime.Day >= 13 && dateTime.Day <= 19);
            case Schedule.Last:
                return datesList.Last();
            default:
                return datesList[(int)schedule - 1];
        }
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        DateTime res = GetMeetUpDate(GetAllWeekDaysOfTheMonth(dayOfWeek), schedule);
        Console.WriteLine(res);
        return res;
    }
}