using ECalendar.Web.Api.Models;
using FluentAssertions;
using Moq;
using Xunit;

namespace ECalendar.Web.Api.Tests.Unit.Services.Foundations.Holidays;

public partial class HolidayServiceTests
{
    [Fact]
    public async Task ShouldRemoveHolidayByIdAsync()
    {
        // given
        Holiday randomHoliday = CreateRandomHoliday();
        Guid holidayId = Guid.NewGuid();
        Holiday storageHoliday = randomHoliday;
        Holiday expectedHoliday = storageHoliday;

        this.storageBrokerMock.Setup(broker =>
                broker.SelectHolidayByIdAsync(holidayId))
            .ReturnsAsync(storageHoliday);

        this.storageBrokerMock.Setup(broker =>
                broker.DeleteHolidayAsync(storageHoliday))
            .ReturnsAsync(expectedHoliday);

        // when
        Holiday actualHoliday =
            await this.holidayService.RemoveHolidayByIdAsync(holidayId);

        // then
        actualHoliday.Should().BeEquivalentTo(expectedHoliday);
        
        this.storageBrokerMock.Verify(broker => 
            broker.SelectHolidayByIdAsync(holidayId),
            Times.Once);
        
        this.storageBrokerMock.Verify(broker => 
            broker.DeleteHolidayAsync(storageHoliday),
            Times.Once);
        
        this.dateTimeBrokerMock.VerifyNoOtherCalls();
        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }
}