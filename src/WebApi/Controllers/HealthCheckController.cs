using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController
    {
        [HttpGet]
        public ActionResult Get()
        {
            return new OkResult();
        }
    }
}
