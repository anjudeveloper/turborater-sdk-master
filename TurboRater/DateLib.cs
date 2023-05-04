using System;

namespace TurboRater
{
  /// <summary>
  /// Container for Date calculation methods and related items.
  /// </summary>
  public sealed class DateLib
  {
    /// <summary>
    /// Hiding default constructor
    /// </summary>
    private DateLib()
    {
    }

    /// <summary>
    /// Checks to see if a date is a valid date.
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <returns>True if the date is valid.</returns>
    public static bool IsValidDateExpanded(DateTime date)
    {
      // taken from delphi version
      if (!ITCConstants.IsValidDate(date))
        return false;

      return date.Year >= 1 && date.Year <= 9999 && date.Month >= 1 &&
        date.Month <= 12 && date.Day >= 1 && date.Day <= DateTime.DaysInMonth(date.Year, date.Month);
    }

    /// <summary>
    /// Returns the days, years and months difference between 2 dates.  The order of the dates 
    /// does not matter.
    /// </summary>
    /// <param name="date1">The first date to compare.</param>
    /// <param name="date2">The second date to compare.</param>
    /// <param name="days">The days difference.</param>
    /// <param name="months">The months difference.</param>
    /// <param name="years">The years difference.</param>
    public static void DateDifference(DateTime date1, DateTime date2, out int days, out int months, out int years)
    {
      days = 0;
      months = 0;
      years = 0;
      if (!IsValidDateExpanded(date1) || !IsValidDateExpanded(date2))
        return;

      if (date1 > date2)
      {
        DateTime tempDate = date1;
        date1 = date2;
        date2 = tempDate;
      }

      int day1 = date1.Day;
      int day2 = date2.Day;
      int month1 = date1.Month;
      int month2 = date2.Month;
      int year1 = date1.Year;
      int year2 = date2.Year;

      if (date2.Day < date1.Day)
      {
        month2 -= 1;
        if (month2 == 0)
        {
          month2 = 12;
          year2 -= 1;
        }
        days = day2 + DateTime.DaysInMonth(year1, month1) - day1;
      }
      else
        days = day2 - day1;

      if (month2 < month1)
      {
        month2 += 12;
        year2 -= 1;
      }

      months = month2 - month1;
      years = year2 - year1;
    }

    /// <summary>
    /// Returns the number of months between 2 dates.
    /// </summary>
    /// <param name="date1">The first date to compare.</param>
    /// <param name="date2">The second date to compare.</param>
    /// <returns>The number of months between the two dates provided.</returns>
    public static int MonthsDifference(DateTime date1, DateTime date2)
    {
      int days = 0;
      int months = 0;
      int years = 0;
      DateDifference(date1, date2, out days, out months, out years);
      return (years * 12) + months;
    }

    /// <summary>
    /// Returns the number of days between 2 dates.
    /// </summary>
    /// <param name="date1">The first date to compare.</param>
    /// <param name="date2">The second date to compare.</param>
    /// <returns>The number of days between the two dates provided.</returns>
    public static int DaysDifference(DateTime date1, DateTime date2)
    {
      return (date2.Date - date1.Date).Days;
    }
  }
}
