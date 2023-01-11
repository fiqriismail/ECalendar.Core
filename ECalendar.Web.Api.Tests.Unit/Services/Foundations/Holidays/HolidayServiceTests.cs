using ECalendar.Web.Api.Brokers.DateTimes;
using ECalendar.Web.Api.Brokers.Loggings;
using ECalendar.Web.Api.Brokers.Storages;
using ECalendar.Web.Api.Models;
using ECalendar.Web.Api.Services.Foundations.Holidays;
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

        this.holidayService = new HolidayService(
            storageBroker: this.storageBrokerMock.Object,
            loggingBroker: this.loggingBrokerMock.Object,
            dateTimeBroker: this.dateTimeBrokerMock.Object);
    }

    private static Holiday CreateRandomHoliday() =>
        CreateHolidayFiller(dates: DateTimeOffset.UtcNow).Create();
    
    private static Holiday CreateRandomHoliday(DateTimeOffset dates) =>
        CreateHolidayFiller(dates: dates).Create();
    
    private static DateTimeOffset GetRandomDateTime() =>
        new DateTimeRange(earliestDate: new DateTime()).GetValue();

    private static Filler<Holiday> CreateHolidayFiller(DateTimeOffset dates)
    {
        var filler = new Filler<Holiday>();

        filler.Setup()
            .OnProperty(holiday => holiday.Day).Use(dates);

        return filler;
    }
}