using ECalendar.Web.Api.Models;
using FluentAssertions;
using Moq;
using Xunit;

namespace ECalendar.Web.Api.Tests.Unit.Services.Foundations.Holidays;

public partial class HolidayServiceTests
{
    [Fact]
    public async Task ShouldModifyHolidayAsync()
    {
        // given 
        DateTimeOffset randomDateTime = GetRandomDateTime();
        Holiday randomHoliday = CreateRandomHoliday(randomDateTime);
        Holiday inputHoliday = randomHoliday;
        Holiday afterUpdateStorageHoliday = inputHoliday;
        Holiday expectedHoliday = afterUpdateStorageHoliday;
        Holiday beforeUpdateStorageHoliday = expectedHoliday;
        Guid holidayId = Guid.NewGuid();

        this.storageBrokerMock.Setup(broker =>
                broker.SelectHolidayByIdAsync(holidayId))
            .ReturnsAsync(beforeUpdateStorageHoliday);

        this.dateTimeBrokerMock.Setup(broker =>
                broker.GetCurrentDateTime())
            .Returns(randomDateTime);

        this.storageBrokerMock.Setup(broker =>
                broker.UpdateHolidayAsync(inputHoliday))
            .ReturnsAsync(afterUpdateStorageHoliday);

        // when
        Holiday actualHoliday =
            await this.holidayService.ModifyHolidayAsync(inputHoliday);
        
        // then
        actualHoliday.Should().BeEquivalentTo(expectedHoliday);
        
        this.storageBrokerMock.Verify(broker => 
            broker.SelectHolidayByIdAsync(holidayId),
            Times.Never);
        
        this.dateTimeBrokerMock.Verify(broker => 
            broker.GetCurrentDateTime(),
            Times.Never); 
        
        this.storageBrokerMock.Verify(broker => 
            broker.UpdateHolidayAsync(inputHoliday),
            Times.Once);
        
        this.dateTimeBrokerMock.VerifyNoOtherCalls();
        this.storageBrokerMock.VerifyNoOtherCalls();
        this.loggingBrokerMock.VerifyNoOtherCalls();
        
    }
}