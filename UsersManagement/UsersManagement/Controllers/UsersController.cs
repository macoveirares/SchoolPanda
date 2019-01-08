using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;
using UsersManagement.Application.DTO;
using UsersManagement.Application.Services;
using UsersManagement.Models;

namespace UsersManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/api/v1/addUser")]
        public ActionResult<HttpResponse> AddUser(UserModel userModel)
        {
            _userService.CreateUser((UserDTO)new UserDTO().InjectFrom(userModel));
            return Ok();
        }

        [HttpPost]
        [Route("/api/v1/deleteUser")]
        public ActionResult<HttpResponse> DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }

        [HttpPost]
        [Route("/api/v1/updateUser")]
        public ActionResult<HttpResponse> UpdateUser(UserModel userModel)
        {
            _userService.UpdateUser((UserDTO)new UserDTO().InjectFrom(userModel));
            return Ok();
        }
    }
}