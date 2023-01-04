using Microsoft.AspNetCore.Mvc.Testing;
using RESTFulSense.Clients;

namespace ECalendar.Web.Api.Tests.Acceptance.Brokers;

public partial class ECalendarApiBroker
{
    private readonly WebApplicationFactory<Program> webApplicationFactory;
    private readonly HttpClient httpClient;
    private readonly IRESTFulApiFactoryClient apiFactoryClient;


    public ECalendarApiBroker()
    {
        this.webApplicationFactory = new WebApplicationFactory<Program>();
        this.httpClient = this.webApplicationFactory.CreateClient();
        this.apiFactoryClient = new RESTFulApiFactoryClient(this.httpClient);
    }
}