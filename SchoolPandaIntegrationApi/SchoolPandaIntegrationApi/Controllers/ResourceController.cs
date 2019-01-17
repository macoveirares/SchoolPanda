using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Omu.ValueInjecter;
using SchoolPanda.Application.Logic;
using SchoolPandaIntegrationAPI.Models;
using System.Collections.Generic;

namespace SchoolPandaIntegrationAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly ResourceManagementMicroservice _resourceManagementMicroservice;
        private readonly IConfiguration _configuration;

        public ResourceController(IConfiguration configuration)
        {
            _resourceManagementMicroservice = new ResourceManagementMicroservice();

            _configuration = configuration;
            var userManagementServiceUrl = _configuration["Microservices:ResourceManagement"];
            _resourceManagementMicroservice = string.IsNullOrEmpty(userManagementServiceUrl) ? new ResourceManagementMicroservice() : new ResourceManagementMicroservice(userManagementServiceUrl);
        }

        [HttpPost]
        [Route("/api/v1/getResource")]
        public ActionResult<ResourceModel> GetResource([FromBody]int id)
        {
            return (ResourceModel) new ResourceModel().InjectFrom(_resourceManagementMicroservice.GetResource(id));
        }

        [HttpPost]
        [Route("/api/v1/getAllLabs")]
        public ActionResult<List<ResourceModel>> GetAllLabs(int userId)
        {
            var resourcesModel = new List<ResourceModel>();
            var resources = _resourceManagementMicroservice.GetAllLabs(userId);
            foreach(var item in resources)
            {
                var temp = (ResourceModel)new ResourceModel().InjectFrom(item);
                resourcesModel.Add(temp);
            }
            return resourcesModel;
        }

        [HttpPost]
        [Route("/api/v1/getCourseResources")]
        public ActionResult<List<ResourceModel>> GetCourseResources(int userId, int courseId)
        {
            var resourceModel = new List<ResourceModel>();
            var resources = _resourceManagementMicroservice.
        }
    }
}