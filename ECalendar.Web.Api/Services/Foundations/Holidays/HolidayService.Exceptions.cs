using ECalendar.Web.Api.Models.Holidays;
using ECalendar.Web.Api.Models.Holidays.Exceptions;

namespace ECalendar.Web.Api.Services.Foundations.Holidays;

public partial class HolidayService
{
    private delegate ValueTask<Holiday> ReturningHolidayFunction();

    private async ValueTask<Holiday> TryCatch(ReturningHolidayFunction returningHolidayFunction)
    {
        try
        {
            return await returningHolidayFunction();
        }
        catch (NullHolidayException nullHolidayException)
        {
            throw CreateAndLogValidationException(nullHolidayException);
        }
        catch (Exception exception)
        {
            throw CreateAndLogServiceException(exception);
        }
    }


    private HolidayValidationException CreateAndLogValidationException(Exception exception)
    {
        var holidayValidationException = new HolidayValidationException(exception);
        this.loggingBroker.LogError(holidayValidationException);

        return holidayValidationException;
    }
    
    private HolidayServiceException CreateAndLogServiceException(Exception exception)
    {
        var holidayServiceException = new HolidayServiceException(exception);
        this.loggingBroker.LogError(holidayServiceException);

        return holidayServiceException;
    }
}