using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;
using ResourceManagement.Api.Models;
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
        [Consumes("multipart/form-data")]
        public void CreateResource(IFormFile formData)
        {
            //_resourceService.CreateResource((ResourceDto)new ResourceDto().InjectFrom(resource));
            //return Ok();
        }

        [HttpPost]
        [Route("/api/v1/getallLabs")]
        public ActionResult<List<ResourceModel>> GetAllLabs([FromBody] ResourceInfo resourceInfo)
        {
            var resourcesModel = new List<ResourceModel>();
            var resources = _resourceService.GetAllLabs(resourceInfo.UserId);
            foreach(var item in resources.Resources)
            {
                var temp = (ResourceModel)new ResourceModel().InjectFrom(item);
                resourcesModel.Add(temp);
            }
            return resourcesModel;
        }

        [HttpPost]
        [Route("/api/v1/getCourseResource")]
        public  ActionResult<List<ResourceModel>> GetAllCourseResources([FromBody] ResourceInfo resourceInfo)
        {
            var resources = _resourceService.GetCourseResources(resourceInfo.UserId, resourceInfo.CourseId);
            var resourceModel = new List<ResourceModel>();
            foreach(var item in resources.Resources)
            {
                var temp = (ResourceModel)new ResourceModel().InjectFrom(item);
                resourceModel.Add(temp);
            }
            return resourceModel;
        }
    }
}