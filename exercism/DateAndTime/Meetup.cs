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
        return daysUntil == 0 ? 0 : daysUntil;
    }
    
    private List<DateTime> GetAllWeekDaysOfTheMonth(DayOfWeek dayOfWeek)
    {
        DateTime firstDay = new DateTime(year, month, 1);
        
        DateTime firstSelectedWeekDateOfMonth = new DateTime(year, month, 1 + DaysUntilNext(firstDay.DayOfWeek, dayOfWeek));

        List<DateTime> datesList = new List<DateTime>{};

        datesList.Add(firstSelectedWeekDateOfMonth);
        
        for (int i = 1; i < 5; i++)
        {
            DateTime currentDate = datesList[i - 1].AddDays(7);
            if (currentDate.Month == firstDay.Month)
            {
                datesList.Add(datesList[i - 1].AddDays(7));
            }

        }
        return datesList;
    }


    private DateTime GetMeetUpDate(List<DateTime> datesList, Schedule schedule)
    {
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

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule) =>
        GetMeetUpDate(GetAllWeekDaysOfTheMonth(dayOfWeek), schedule);
}