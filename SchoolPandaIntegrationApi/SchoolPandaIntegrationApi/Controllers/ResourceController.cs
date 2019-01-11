using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Omu.ValueInjecter;
using SchoolPanda.Application.Logic;
using SchoolPandaIntegrationAPI.Models;

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
    }
}