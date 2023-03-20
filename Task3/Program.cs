namespace Task3;
using System;
public class Program
{
    static void Main(string[] args) {
        Year year = new Year();
        year.Day = new Day();
        year.Month = new Month();

        year.SetDate(2023, 3, 19);
        Console.WriteLine(year.GetDayOfWeek()); 

        Year otherYear = new Year();
        otherYear.Day = new Day();
        otherYear.Month = new Month();
        otherYear.SetDate(2023, 3, 20);
        Console.WriteLine(year.GetDaysInRange(otherYear)); 
        Console.WriteLine(year.GetMonthsInRange(otherYear));
    }
}
public class Day
{
    private int day;

    public int Value
    {
        get { return day; }
        set
        {
            if (value < 1 || value > 31)
                throw new ArgumentException("Invalid day value");
            day = value;
        }
    }
}

public class Month
{
    private int month;

    public int Value
    {
        get { return month; }
        set
        {
            if (value < 1 || value > 12)
                throw new ArgumentException("Invalid month value");
            month = value;
        }
    }
}

public class Year
{
    private int year;

    public int Value
    {
        get { return year; }
        set
        {
            if (value < 1)
                throw new ArgumentException("Invalid year value");
            year = value;
        }
    }

    public Day Day { get; set; }
    public Month Month { get; set; }

    public void SetDate(int year, int month, int day)
    {
        Value = year;
        Month.Value = month;
        Day.Value = day;
    }

    public DayOfWeek GetDayOfWeek()
    {
        return new DateTime(Value, Month.Value, Day.Value).DayOfWeek;
    }

    public int GetDaysInRange(Year otherYear)
    {
        DateTime date1 = new DateTime(Value, Month.Value, Day.Value);
        DateTime date2 = new DateTime(otherYear.Value, otherYear.Month.Value, otherYear.Day.Value);
        TimeSpan span = date2 - date1;
        return span.Days;
    }

    public int GetMonthsInRange(Year otherYear)
    {
        int months = Math.Abs(otherYear.Value - Value) * 12;
        months -= Month.Value;
        months += otherYear.Month.Value;
        return months;
    }
}
