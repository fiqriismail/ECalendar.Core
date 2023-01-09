using ECalendar.Web.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ECalendar.Web.Api.Brokers.Storages;

public partial class StorageBroker : IStorageBroker
{
    public DbSet<Holiday> Holidays { get; set; }
    
    public async ValueTask<Holiday> InsertHolidayAsync(Holiday holiday)
    {
        this.Entry(holiday).State = EntityState.Added;
        await this.SaveChangesAsync();

        return holiday;
    }

    public IQueryable<Holiday> SelectAllHolidays() => 
        this.Holidays.AsQueryable();
    

    public async ValueTask<Holiday> SelectHolidayByIdAsync(Guid holidayId) => 
        await this.Holidays.FindAsync(holidayId);
    

    public async ValueTask<Holiday> UpdateHolidayAsync(Holiday holiday)
    {
        this.Entry(holiday).State = EntityState.Modified;
        await this.SaveChangesAsync();

        return holiday;
    }

    public async ValueTask<Holiday> DeleteHolidayAsync(Holiday holiday)
    {
        this.Entry(holiday).State = EntityState.Deleted;
        await this.SaveChangesAsync();

        return holiday;
    }
}