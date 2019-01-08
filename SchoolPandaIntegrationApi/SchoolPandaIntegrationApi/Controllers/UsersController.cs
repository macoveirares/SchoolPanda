using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Omu.ValueInjecter;
using SchoolPanda.Application.DTO;
using SchoolPanda.Application.Logic;
using SchoolPandaIntegrationAPI.Models;
using System.Collections.Generic;

namespace SchoolPandaIntegrationAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManagementMicroservice _userManagementMicroservice;
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
            var userManagementServiceUrl = _configuration["Microservices:UserManagement"];
            _userManagementMicroservice = string.IsNullOrEmpty(userManagementServiceUrl) ? new UserManagementMicroservice() : new UserManagementMicroservice(userManagementServiceUrl);
        }

        [HttpGet]
        public ActionResult<List<RoleDto>> GetRoles()
            => _userManagementMicroservice.GetRoles();

        [HttpGet("id")]
        public ActionResult<List<UserDto>> GetUSers(int id)
            => _userManagementMicroservice.GetUsers();

        [HttpGet("userId")]
        public ActionResult<string> GetUserInfo(int userId)
        {

            return "`";
        }

        [HttpPost]
        [Route("/api/v1/createUser")]
        public ActionResult<HttpResponse> AddUser(CreateUserModel user)
        {
            var userDto =(UserDto) new UserDto().InjectFrom(user);
            _userManagementMicroservice.CreateUser(userDto);
            return Ok();
        }
    }
}