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
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService _courseService)
        {
            this._courseService = _courseService;
        }

        [HttpPost]
        [Route("/api/v1/addUser")]
        public ActionResult<HttpResponse> AddCourse(CourseModel courseModel)
        {
            _courseService.CreateCourse((CourseDTO)new CourseDTO().InjectFrom(courseModel));
            return Ok();
        }

        [HttpPost]
        [Route("/api/v1/deleteUser")]
        public ActionResult<HttpResponse> DeleteUser(int id)
        {
            _courseService.DeleteCourse(id);
            return Ok();
        }

        [HttpPost]
        [Route("/api/v1/deleteUser")]
        public ActionResult<HttpResponse> UpdateUser(CourseModel courseModel)
        {
            _courseService.UpdateCourse((CourseDTO)new CourseDTO().InjectFrom(courseModel));
            return Ok();
        }
    }
}