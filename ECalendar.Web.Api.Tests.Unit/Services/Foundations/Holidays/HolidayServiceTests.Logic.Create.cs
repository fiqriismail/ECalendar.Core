using ECalendar.Web.Api.Models.Holidays;
using FluentAssertions;
using Moq;
using Xunit;

namespace ECalendar.Web.Api.Tests.Unit.Services.Foundations.Holidays;

public partial class HolidayServiceTests
{
    [Fact]
    public async Task ShouldCreateHolidayAsync()
    {
        // given
        DateTimeOffset randomDateTime = GetRandomDateTime();
        DateTimeOffset dateTime = randomDateTime;
        Holiday randomHoliday = CreateRandomHoliday(randomDateTime);
        Holiday inputHoliday = randomHoliday;
        Holiday storageHoliday = inputHoliday;
        Holiday expectedHoliday = storageHoliday;

        this.dateTimeBrokerMock.Setup(broker => 
            broker.GetCurrentDateTime())
                .Returns(dateTime);

        this.storageBrokerMock.Setup(broker => 
            broker.InsertHolidayAsync(inputHoliday))
                .ReturnsAsync(storageHoliday);

        // when 
        Holiday actualHoliday =
            await this.holidayService.CreateHolidayAsync(inputHoliday);

        // then 
        actualHoliday.Should().BeEquivalentTo(expectedHoliday);
        
        this.dateTimeBrokerMock.Verify(broker => 
                broker.GetCurrentDateTime(),
                Times.Never);

        this.storageBrokerMock.Verify(broker => 
            broker.InsertHolidayAsync(inputHoliday),
            Times.Once);
        
        this.dateTimeBrokerMock.VerifyNoOtherCalls();
        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
    }
}