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

        [HttpGet]
        [Route("/api/v1/getUserMarks")]
        public ActionResult<List<MarkModel>> GetUserMarks([FromBody]int id)
        {
            return _userManagementMicroservice.GetUserMarks(id).Select(x => (MarkModel)new MarkModel().InjectFrom(x)).ToList();
        }

        [HttpGet]
        [Route("/api/v1/getUserAttendances")]
        public ActionResult<List<AttendanceModel>> GetUserAttendances([FromBody]int id)
        {
            return _userManagementMicroservice.GetUserAttendances(id).Select(x => (AttendanceModel)new AttendanceModel().InjectFrom(x)).ToList();
        }

        [HttpGet]
        [Route("/api/v1/getCourses")]
        public ActionResult<List<CourseModel>> GetCourses()
        {
            return _userManagementMicroservice.GetCourses().Select(x => (CourseModel)new CourseModel().InjectFrom(x)).ToList();
        }

        [HttpPost]
        [Route("/api/v1/createCourse")]
        public ActionResult<HttpResponse> AddCourse([FromBody]CourseModel course)
        {
            var courseDto = (CourseDto)new CourseDto().InjectFrom(course);
            _userManagementMicroservice.AddCourse(courseDto);
            return Ok();
        }

        [HttpPost]
        [Route("/api/v1/deleteCourse")]
        public ActionResult<HttpResponse> DeleteCourse([FromBody]int id)
        {
            _userManagementMicroservice.DeleteCourse(id);
            return Ok();
        }

        [HttpPost]
        [Route("/api/v1/updateCourse")]
        public ActionResult<HttpResponse> UpdateCourse([FromBody]CourseModel course)
        {
            var courseDto = (CourseDto)new CourseDto().InjectFrom(course);
            _userManagementMicroservice.UpdateCourse(courseDto);
            return Ok();
        }

        [HttpPost]
        [Route("/api/v1/createAttendance")]
        public ActionResult<HttpResponse> AddAttendance([FromBody]AttendanceModel attendance)
        {
            var attendanceDto = (AttendanceDto)new AttendanceDto().InjectFrom(attendance);
            _userManagementMicroservice.AddAttendance(attendanceDto);
            return Ok();
        }

        [HttpPost]
        [Route("/api/v1/deleteAttendance")]
        public ActionResult<HttpResponse> DeleteAttendance([FromBody]int id)
        {
            _userManagementMicroservice.DeleteAttendance(id);
            return Ok();
        }

        [HttpPost]
        [Route("/api/v1/updateAttendance")]
        public ActionResult<HttpResponse> UpdateAttendance([FromBody]AttendanceModel attendance)
        {
            var attendanceDto = (AttendanceDto)new AttendanceDto().InjectFrom(attendance);
            _userManagementMicroservice.UpdateAttendance(attendanceDto);
            return Ok();
        }

        [HttpGet]
        [Route("/api/v1/getUserCourses")]
        public ActionResult<List<CourseModel>> GetUserCourses([FromBody]int id)
        {
            return _userManagementMicroservice.GetUserCourses(id).Select(x => (CourseModel)new CourseModel().InjectFrom(x)).ToList();
        }
    }
}