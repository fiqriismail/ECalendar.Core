using ECalendar.Web.Api.Models;
using FluentAssertions;
using Moq;
using Xunit;

namespace ECalendar.Web.Api.Tests.Unit.Services.Foundations.Holidays;

public partial class HolidayServiceTests
{
    [Fact]
    public async Task ShouldRetrieveHolidayByIdAsync()
    {
        // given
        Guid randomHolidayId = Guid.NewGuid();
        Guid inputHolidayId = randomHolidayId;
        DateTimeOffset randomDateTime = GetRandomDateTime();
        Holiday randomHoliday = CreateRandomHoliday(randomDateTime);
        Holiday storageHoliday = randomHoliday;
        Holiday expectedHoliday = storageHoliday;

        this.storageBrokerMock.Setup(broker =>
                broker.SelectHolidayByIdAsync(inputHolidayId))
                    .ReturnsAsync(storageHoliday);

        // when
        Holiday actualHoliday =
            await this.holidayService.RetrieveHolidayByIdAsync(inputHolidayId);

        // then
        actualHoliday.Should().BeEquivalentTo(expectedHoliday);
        
        this.dateTimeBrokerMock.Verify(broker => 
            broker.GetCurrentDateTime(),
                Times.Never);
        
        this.storageBrokerMock.Verify(broker => 
            broker.SelectHolidayByIdAsync(inputHolidayId),
            Times.Once);
        
        this.dateTimeBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
        this.storageBrokerMock.VerifyNoOtherCalls();


    }
}