using Xunit;

namespace ECalendar.Web.Api.Tests.Acceptance.Brokers;

[CollectionDefinition(nameof(ApiTestCollection))]
public class ApiTestCollection : ICollectionFixture<ECalendarApiBroker>
{
}