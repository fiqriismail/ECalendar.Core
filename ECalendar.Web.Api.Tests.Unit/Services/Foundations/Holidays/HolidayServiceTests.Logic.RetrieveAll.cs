using ECalendar.Web.Api.Models;
using FluentAssertions;
using Moq;
using Xunit;

namespace ECalendar.Web.Api.Tests.Unit.Services.Foundations.Holidays;

public partial class HolidayServiceTests
{
    [Fact]
    public void ShouldRetrieveAllHolidays()
    {
        // given
        DateTimeOffset randomDateTime = GetRandomDateTime();
        IQueryable<Holiday> randomHolidays = CreateRandomHolidays(randomDateTime);
        IQueryable<Holiday> storageHolidays = randomHolidays;
        IQueryable<Holiday> expectedHolidays = storageHolidays;

        this.storageBrokerMock.Setup(broker =>
                broker.SelectAllHolidays())
                    .Returns(storageHolidays);

        // when
        IQueryable<Holiday> actualHolidays =
            this.holidayService.RetrieveAllHolidays();

        // then
        actualHolidays.Should().BeEquivalentTo(expectedHolidays);
        
        this.dateTimeBrokerMock.Verify(broker => 
            broker.GetCurrentDateTime(),
             Times.Never);
        
        this.storageBrokerMock.Verify(broker => 
            broker.SelectAllHolidays(),
            Times.Once);
        
        this.dateTimeBrokerMock.VerifyNoOtherCalls();
        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();

    }
}