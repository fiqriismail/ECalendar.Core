using ECalendar.Web.Api.Models.Holidays;
using ECalendar.Web.Api.Models.Holidays.Exceptions;

namespace ECalendar.Web.Api.Services.Foundations.Holidays;

public partial class HolidayService
{
    private void ValidateHolidayOnCreate(Holiday holiday)
    {
        
    }

    private static void ValidateHoliday(Holiday holiday)
    {
        if (holiday is null)
        {
            throw new NullHolidayException();
        }
    }
}