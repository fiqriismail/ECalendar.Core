using ECalendar.Web.Api.Brokers.DateTimes;
using ECalendar.Web.Api.Brokers.Loggings;
using ECalendar.Web.Api.Brokers.Storages;
using ECalendar.Web.Api.Models;

namespace ECalendar.Web.Api.Services.Foundations.Holidays;

public class HolidayService : IHolidayService
{
    private readonly IDateTimeBroker dateTimeBroker;
    private readonly ILoggingBroker loggingBroker;
    private readonly IStorageBroker storageBroker;

    public HolidayService(
        IStorageBroker storageBroker,
        ILoggingBroker loggingBroker,
        IDateTimeBroker dateTimeBroker)
    {
        this.storageBroker = storageBroker;
        this.loggingBroker = loggingBroker;
        this.dateTimeBroker = dateTimeBroker;
    }

    public async ValueTask<Holiday> CreateHolidayAsync(Holiday holiday)
    {
        return await this.storageBroker.InsertHolidayAsync(holiday);
    }

    public IQueryable<Holiday> RetrieveAllHolidays()
    {
        throw new NotImplementedException();
    }

    public async ValueTask<Holiday> RetrieveHolidayByIdAsync(Guid holidayId)
    {
        return await this.storageBroker.SelectHolidayByIdAsync(holidayId);
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