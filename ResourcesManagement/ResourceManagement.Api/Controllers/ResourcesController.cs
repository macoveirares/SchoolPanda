using Microsoft.AspNetCore.Mvc;

namespace ResourceManagement.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {


        public ResourcesController()
        {

        }
        
        [HttpPost]
        [Route("/api/v1/getresource")]
        public ActionResult<string> GetResource(int id)
        {
            return "ad";
        }
    }
}