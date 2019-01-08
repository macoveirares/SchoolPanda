using Microsoft.AspNetCore.Mvc;

namespace SchoolPandaIntegrationAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetAll()
        {
            return "da";
        }
    }
}