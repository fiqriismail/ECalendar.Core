using ECalendar.Web.Api.Tests.Acceptance.Brokers;
using FluentAssertions;
using Xunit;

namespace ECalendar.Web.Api.Tests.Acceptance.APIs.Homes;

[Collection(nameof(ApiTestCollection))]
public class HomeApiTests
{
    private readonly ECalendarApiBroker eCalendarApiBroker;

    public HomeApiTests(ECalendarApiBroker eCalendarApiBroker)
    {
        this.eCalendarApiBroker = eCalendarApiBroker;
    }

    [Fact]
    public async Task ShouldReturnHomeMessageAsync()
    {
        // given
        const string expectedMessage =
            "The stuff you are looking for is not here!";

        // when
        var actualMessage =
            await eCalendarApiBroker.GetHomeMessageAsync();

        // then 
        actualMessage.Should().BeEquivalentTo(expectedMessage);
    }
}