using ECalendar.Web.Api.Models.Holidays;
using ECalendar.Web.Api.Models.Holidays.Exceptions;
using Moq;
using Xunit;
using Xunit.Sdk;

namespace ECalendar.Web.Api.Tests.Unit.Services.Foundations.Holidays;

public partial class HolidayServiceTests
{
    [Fact]
    public async void ShouldThrowValidationExceptionOnCreateWhenHolidayIsNullAndLogItAsync()
    {
        // given
        Holiday invalidHoliday = null;
        var nullHolidayException = new NullHolidayException();

        var expectedHolidayValidationException =
            new HolidayValidationException(nullHolidayException);

        // when 
        ValueTask<Holiday> createHolidayTask =
            this.holidayService.CreateHolidayAsync(invalidHoliday);

        // then
        await Assert.ThrowsAsync<HolidayValidationException>(() =>
            createHolidayTask.AsTask());

        this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedHolidayValidationException))),
            Times.Once);

        this.storageBrokerMock.Verify(broker =>
                broker.InsertHolidayAsync(It.IsAny<Holiday>()),
            Times.Never);
        
        this.loggingBrokerMock.VerifyNoOtherCalls();
        this.storageBrokerMock.VerifyNoOtherCalls();
        this.dateTimeBrokerMock.VerifyNoOtherCalls();
    }
}