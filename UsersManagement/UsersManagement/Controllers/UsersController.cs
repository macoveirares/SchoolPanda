using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using UsersManagement.Application.DTO;
using UsersManagement.Application.Services;
using UsersManagement.Models;

namespace UsersManagement.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMarkService _markService;

        public UsersController(IUserService userService, IMarkService markService)
        {
            _userService = userService;
            _markService = markService;
        }

        [HttpPost]
        [Route("/api/v1/addUser")]
        public ActionResult<HttpResponse> AddUser([FromBody]UserModel userModel)
        {
            _userService.CreateUser((UserDTO)new UserDTO().InjectFrom(userModel));
            return Ok();
        }

        [HttpPost()]
        [Route("/api/v1/deleteUser")]
        public ActionResult<HttpResponse> DeleteUser([FromBody]int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }

        [HttpPost]
        [Route("/api/v1/updateUser")]
        public ActionResult<HttpResponse> UpdateUser([FromBody]UserModel userModel)
        {
            _userService.UpdateUser((UserDTO)new UserDTO().InjectFrom(userModel));
            return Ok();
        }

        [HttpGet]
        [Route("/api/v1/getUsers")]
        public ActionResult<List<UserModel>> GetUsers()
        {
            return _userService.GetAllUsers().Select(x => (UserModel)new UserModel().InjectFrom(x)).ToList();
        }

        [HttpGet]
        [Route("/api/v1/getRoles")]
        public ActionResult<List<RoleModel>> GetRoles()
        {
            return _userService.GetRoles().Select(x => (RoleModel)new RoleModel().InjectFrom(x)).ToList();
        }

        [HttpGet]
        [Route("/api/v1/getUser")]
        public ActionResult<UserModel> GetUser([FromBody]int id)
        {
            var user = _userService.GetUserById(id);
            return (UserModel)new UserModel().InjectFrom(user);
        }

        [HttpGet]
        [Route("/api/v1/getUsersByCourse")]
        public ActionResult<List<UserModel>> GetUsersByCourse([FromBody]int id)
        {
            return _userService.GetUsersByCourse(id).Select(x => (UserModel)new UserModel().InjectFrom(x)).ToList();
        }

        [HttpPost]
        [Route("/api/v1/addMark")]
        public ActionResult<HttpResponse> AddMark([FromBody]MarkModel markModel)
        {
            _markService.AddMark((MarkDTO)new MarkDTO().InjectFrom(markModel));
            return Ok();
        }

        [HttpPost()]
        [Route("/api/v1/deleteMark")]
        public ActionResult<HttpResponse> DeleteMark([FromBody]int id)
        {
            _markService.DeleteMark(id);
            return Ok();
        }

        [HttpPost]
        [Route("/api/v1/updateMark")]
        public ActionResult<HttpResponse> UpdateMark([FromBody]MarkModel markModel)
        {
            _markService.UpdateMark((MarkDTO)new MarkDTO().InjectFrom(markModel));
            return Ok();
        }

        [HttpGet]
        [Route("/api/v1/getMark")]
        public ActionResult<MarkModel> GetMark([FromBody]int id)
        {
            var mark = _markService.GetMarkById(id);
            return (MarkModel)new MarkModel().InjectFrom(mark);
        }

        [HttpGet]
        [Route("/api/v1/getUserMarks")]
        public ActionResult<List<MarkModel>> GetUserMarks([FromBody]int id)
        {
            return _markService.GetUserMarks(id).Select(x => (MarkModel)new MarkModel().InjectFrom(x)).ToList();
        }

        [HttpPost]
        [Route("/api/v1/addRole")]
        public ActionResult<HttpResponse> AddRole([FromBody]RoleModel roleModel)
        {
            _userService.AddRole((RoleDto)new RoleDto().InjectFrom(roleModel));
            return Ok();
        }

        [HttpPost()]
        [Route("/api/v1/deleteRole")]
        public ActionResult<HttpResponse> DeleteRole([FromBody]int id)
        {
            _userService.DeleteRole(id);
            return Ok();
        }

        [HttpPost]
        [Route("/api/v1/updateRole")]
        public ActionResult<HttpResponse> UpdateRole([FromBody]RoleModel roleModel)
        {
            _userService.UpdateRole((RoleDto)new RoleDto().InjectFrom(roleModel));
            return Ok();
        }

    }
}