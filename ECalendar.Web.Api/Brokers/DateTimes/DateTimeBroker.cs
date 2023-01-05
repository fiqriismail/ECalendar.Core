namespace ECalendar.Web.Api.Brokers.DateTimes;

public class DateTimeBroker : IDateTimeBroker
{
    public DateTimeOffset GetDateTime()
    {
        return DateTimeOffset.UtcNow;
    }
}