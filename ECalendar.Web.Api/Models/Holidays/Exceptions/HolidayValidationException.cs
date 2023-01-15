namespace ECalendar.Web.Api.Models.Holidays.Exceptions;

public class HolidayValidationException : Exception
{
    public HolidayValidationException(Exception innerException)
        : base(message: "Invalid input, contact support.", innerException)
    {
    }
}