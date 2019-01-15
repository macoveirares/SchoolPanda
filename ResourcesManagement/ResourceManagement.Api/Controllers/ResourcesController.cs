using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;
using ResourceManagement.Api.Models;
using ResourceManagement.Application.Services;

namespace ResourceManagement.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourcesController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }
        
        [HttpPost]
        [Route("/api/v1/getresource")]
        public ActionResult<ResourceModel> GetResource([FromBody]int id)
        {
            return (ResourceModel)new ResourceModel().InjectFrom(_resourceService.GetResource(id));
        }
        
        [HttpPost]
        [Route("/api/v1/createResource")]
        public void CreateResource([FromBody] IFormFile formData)
        {
            //_resourceService.CreateResource((ResourceDto)new ResourceDto().InjectFrom(resource));
            //return Ok();
        }
        
        [HttpPost]
        [Route("/api/v1/getallLabs")]
        public void GetAllLabs([FromBody] ResourceInfo resourceInfo)
        {

        }
    }
}