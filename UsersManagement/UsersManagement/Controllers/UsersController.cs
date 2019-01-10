using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;
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

        public UsersController(IUserService userService)
        {
            _userService = userService;
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
    }
}