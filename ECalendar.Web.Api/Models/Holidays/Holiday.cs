namespace ECalendar.Web.Api.Models.Holidays;

public class Holiday
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public bool IsPoyaDay { get; set; }
    public bool IsPublic { get; set; }
    public bool IsMercantile { get; set; }
    public bool IsBank { get; set; }
    public bool IsOther { get; set; }
    public DateTimeOffset Day { get; set; }
}