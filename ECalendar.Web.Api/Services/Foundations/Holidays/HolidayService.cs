using ECalendar.Web.Api.Models;

namespace ECalendar.Web.Api.Services.Foundations.Holidays;

public class HolidayService : IHolidayService
{
    public async ValueTask<Holiday> CreateHolidayAsync(Holiday holiday)
    {
        throw new NotImplementedException();
    }

    public IQueryable<Holiday> RetrieveAllHolidays()
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Holiday> RetrieveHolidayByIdAsync(Guid holidayId)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Holiday> ModifyHolidayAsync(Holiday holiday)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Holiday> RemoveHolidayByIdAsync(Guid holidayId)
    {
        throw new NotImplementedException();
    }
}