namespace ECalendar.Web.Api.Models.Holidays.Exceptions;

public class NullHolidayException : Exception
{
    public NullHolidayException() 
        : base(message: "The holiday is null")
    {
    }
}