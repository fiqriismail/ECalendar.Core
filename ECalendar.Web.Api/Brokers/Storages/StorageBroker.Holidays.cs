using ECalendar.Web.Api.Models.Holidays;
using EFxceptions;
using Microsoft.EntityFrameworkCore;

namespace ECalendar.Web.Api.Brokers.Storages;

public partial class StorageBroker : EFxceptionsContext, IStorageBroker
{
    public DbSet<Holiday> Holidays { get; set; }

    public async ValueTask<Holiday> InsertHolidayAsync(Holiday holiday)
    {
        Entry(holiday).State = EntityState.Added;
        await SaveChangesAsync();

        return holiday;
    }

    public IQueryable<Holiday> SelectAllHolidays()
    {
        return Holidays.AsQueryable();
    }


    public async ValueTask<Holiday> SelectHolidayByIdAsync(Guid holidayId)
    {
        return await Holidays.FindAsync(holidayId);
    }


    public async ValueTask<Holiday> UpdateHolidayAsync(Holiday holiday)
    {
        Entry(holiday).State = EntityState.Modified;
        await SaveChangesAsync();

        return holiday;
    }

    public async ValueTask<Holiday> DeleteHolidayAsync(Holiday holiday)
    {
        Entry(holiday).State = EntityState.Deleted;
        await SaveChangesAsync();

        return holiday;
    }
}