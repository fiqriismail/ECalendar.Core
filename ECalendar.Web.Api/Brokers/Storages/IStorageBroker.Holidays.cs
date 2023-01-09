using ECalendar.Web.Api.Models;

namespace ECalendar.Web.Api.Brokers.Storages;

public partial interface IStorageBroker
{
    ValueTask<Holiday> InsertHolidayAsync(Holiday holiday);
    IQueryable<Holiday> SelectAllHolidays();
    ValueTask<Holiday> SelectHolidayByIdAsync(Guid holidayId);
    ValueTask<Holiday> UpdateHolidayAsync(Holiday holiday);
    ValueTask<Holiday> DeleteHolidayAsync(Holiday holiday);
}