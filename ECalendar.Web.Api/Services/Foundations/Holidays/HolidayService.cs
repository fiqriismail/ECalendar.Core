using ECalendar.Web.Api.Brokers.DateTimes;
using ECalendar.Web.Api.Brokers.Logings;
using ECalendar.Web.Api.Brokers.Storages;
using ECalendar.Web.Api.Models;

namespace ECalendar.Web.Api.Services.Foundations.Holidays;

public class HolidayService : IHolidayService
{
    private readonly IStorageBroker storageBroker;
    private readonly ILogingBroker loggingBroker;
    private readonly IDateTimeBroker dateTimeBroker;

    public HolidayService(
        IStorageBroker storageBroker,
        ILogingBroker loggingBroker,
        IDateTimeBroker dateTimeBroker)
    {
        this.storageBroker = storageBroker;
        this.loggingBroker = loggingBroker;
        this.dateTimeBroker = dateTimeBroker;
    }
    
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