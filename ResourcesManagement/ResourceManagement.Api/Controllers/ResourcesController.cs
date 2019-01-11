using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;
using ResourceManagement.Api.Models;
using ResourceManagement.Application.DTO;
using ResourceManagement.Application.Services;
using System.Collections.Generic;

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
        public ActionResult<HttpResponse> CreateResource([FromBody] ResourceModel resource)
        {
            _resourceService.CreateResource((ResourceDto)new ResourceDto().InjectFrom(resource));
            return Ok();
        }
    }
}