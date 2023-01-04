using Microsoft.AspNetCore.Mvc;

namespace ECalendar.Web.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "The stuff you are looking for is not here!";
        }
    }
}
