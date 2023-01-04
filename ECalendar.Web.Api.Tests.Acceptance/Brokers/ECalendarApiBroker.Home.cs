namespace ECalendar.Web.Api.Tests.Acceptance.Brokers;

public partial class ECalendarApiBroker
{
    private const string homeRelativeUrl = "api/home";

    public async ValueTask<string> GetHomeMessageAsync() =>
        await this.apiFactoryClient.GetContentStringAsync(homeRelativeUrl);
}