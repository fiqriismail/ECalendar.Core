using Microsoft.AspNetCore.Mvc.Testing;
using RESTFulSense.Clients;

namespace ECalendar.Web.Api.Tests.Acceptance.Brokers;

public partial class ECalendarApiBroker
{
    private readonly IRESTFulApiFactoryClient apiFactoryClient;
    private readonly HttpClient httpClient;
    private readonly WebApplicationFactory<Program> webApplicationFactory;


    public ECalendarApiBroker()
    {
        webApplicationFactory = new WebApplicationFactory<Program>();
        httpClient = webApplicationFactory.CreateClient();
        apiFactoryClient = new RESTFulApiFactoryClient(httpClient);
    }
}