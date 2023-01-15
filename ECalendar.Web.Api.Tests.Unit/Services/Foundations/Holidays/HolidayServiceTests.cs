using System.Linq.Expressions;
using ECalendar.Web.Api.Brokers.DateTimes;
using ECalendar.Web.Api.Brokers.Loggings;
using ECalendar.Web.Api.Brokers.Storages;
using ECalendar.Web.Api.Models.Holidays;
using ECalendar.Web.Api.Services.Foundations.Holidays;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Moq;
using Tynamix.ObjectFiller;

namespace ECalendar.Web.Api.Tests.Unit.Services.Foundations.Holidays;

public partial class HolidayServiceTests
{
    private readonly Mock<IStorageBroker> storageBrokerMock;
    private readonly Mock<ILoggingBroker> loggingBrokerMock;
    private readonly Mock<IDateTimeBroker> dateTimeBrokerMock;
    private readonly IHolidayService holidayService;

    public HolidayServiceTests()
    {
        this.storageBrokerMock = new Mock<IStorageBroker>();
        this.dateTimeBrokerMock = new Mock<IDateTimeBroker>();
        this.loggingBrokerMock = new Mock<ILoggingBroker>();

        this.holidayService = new HolidayService (
            storageBroker: this.storageBrokerMock.Object,
            loggingBroker: this.loggingBrokerMock.Object,
            dateTimeBroker: this.dateTimeBrokerMock.Object);
    }

    private static int GetRandomNumber() => new IntRange(min: 2, max: 10).GetValue();
    
    private static DateTimeOffset GetRandomDateTime() =>
        new DateTimeRange(earliestDate: new DateTime()).GetValue();
    private static Holiday CreateRandomHoliday() =>
        CreateHolidayFiller(dates: DateTimeOffset.UtcNow).Create();
    
    private static Holiday CreateRandomHoliday(DateTimeOffset dates) =>
        CreateHolidayFiller(dates: dates).Create();

    private static IQueryable<Holiday> CreateRandomHolidays(DateTimeOffset dates) =>
        CreateHolidayFiller(dates).Create(GetRandomNumber()).AsQueryable();
    
    private static Expression<Func<Exception, bool>> SameExceptionAs(Exception expectedException)
    {
        return actualException =>
            actualException.Message == expectedException.Message
            && actualException.InnerException.Message == expectedException.InnerException.Message;
    }
    
    private static Filler<Holiday> CreateHolidayFiller(DateTimeOffset dates)
    {
        var filler = new Filler<Holiday>();

        filler.Setup()
            .OnProperty(holiday => holiday.Day).Use(dates);

        return filler;
    }
}