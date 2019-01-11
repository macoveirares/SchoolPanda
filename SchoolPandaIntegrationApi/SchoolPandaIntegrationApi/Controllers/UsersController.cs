using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Omu.ValueInjecter;
using SchoolPanda.Application.DTO;
using SchoolPanda.Application.Logic;
using SchoolPandaIntegrationAPI.Models;
using System.Collections.Generic;
using System.Linq;

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

        [HttpPost]
        [Route("/api/v1/createUser")]
        public ActionResult<HttpResponse> AddUser([FromBody]UserModel user)
        {
            var userDto = (UserDto)new UserDto().InjectFrom(user);
            _userManagementMicroservice.CreateUser(userDto);
            return Ok();
        }

        [HttpPost]
        [Route("/api/v1/createRole")]
        public ActionResult<HttpResponse> AddRole([FromBody]RoleModel role)
        {
            var roleDto = (RoleDto)new RoleDto().InjectFrom(role);
            _userManagementMicroservice.AddRole(roleDto);
            return Ok();
        }

        [HttpPost]
        [Route("/api/v1/deleteRole")]
        public ActionResult<HttpResponse> DeleteRole([FromBody]int id)
        {
            _userManagementMicroservice.DeleteRole(id);
            return Ok();
        }

        [HttpPost]
        [Route("/api/v1/updateRole")]
        public ActionResult<HttpResponse> UpdateRole([FromBody]RoleDto role)
        {
            var roleDto = (RoleDto)new RoleDto().InjectFrom(role);
            _userManagementMicroservice.UpdateRole(roleDto);
            return Ok();
        }

        [HttpGet]
        [Route("/api/v1/getUsers")]
        public ActionResult<List<UserModel>> GetUsers()
        {
            return _userManagementMicroservice.GetUsers().Select(x => (UserModel)new UserModel().InjectFrom(x)).ToList();
        }

        [HttpGet]
        [Route("/api/v1/getRoles")]
        public ActionResult<List<RoleModel>> GetRoles()
        {
            return _userManagementMicroservice.GetRoles().Select(x => (RoleModel)new RoleModel().InjectFrom(x)).ToList();
        }
    }
}