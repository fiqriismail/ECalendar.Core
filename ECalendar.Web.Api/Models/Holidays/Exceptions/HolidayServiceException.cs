namespace ECalendar.Web.Api.Models.Holidays.Exceptions;

public class HolidayServiceException : Exception
{
    public HolidayServiceException(Exception innerException)
        : base(message: "Service error, contact support", innerException)
    {
    }
}