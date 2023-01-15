using ECalendar.Web.Api.Models.Holidays;

namespace ECalendar.Web.Api.Services.Foundations.Holidays;

public interface IHolidayService
{
    ValueTask<Holiday> CreateHolidayAsync(Holiday holiday);
    IQueryable<Holiday> RetrieveAllHolidays();
    ValueTask<Holiday> RetrieveHolidayByIdAsync(Guid holidayId);
    ValueTask<Holiday> ModifyHolidayAsync(Holiday holiday);
    ValueTask<Holiday> RemoveHolidayByIdAsync(Guid holidayId);
}