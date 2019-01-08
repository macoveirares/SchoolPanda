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
        public ActionResult<HttpResponse> AddUser(CreateUserModel userModel)
        {
            _userService.CreateUser((UserDTO)new UserDTO().InjectFrom(userModel));
            return Ok();
        }
    }
}