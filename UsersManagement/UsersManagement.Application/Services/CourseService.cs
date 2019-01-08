using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using UsersManagement.Application.DTO;
using UsersManagement.Data.Infrastructure;
using UsersManagement.Domain.Entities;

namespace UsersManagement.Application.Services
{
    public interface ICourseService
    {
        void CreateCourse(CourseDTO course);
        List<CourseDTO> GetAllCourses();
        CourseDTO GetCourseById(int id);
        bool UpdateCourse(CourseDTO course);
        bool DeleteCourse(int courseId);
        List<CourseDTO> GetCoursesByUser(int userId);
    }

    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> courseRepository;
        private readonly IRepository<User> userRepository;
        private readonly IUnitOfWork unitOfWork;

        public CourseService(IRepository<Course> courseRepository, IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            this.courseRepository = courseRepository;
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateCourse(CourseDTO course)
        {
            courseRepository.Insert((Course)new Course().InjectFrom(course));
            unitOfWork.Save();
        }

        public List<CourseDTO> GetAllCourses()
        {
            return courseRepository.Query().Select(x => (CourseDTO)new CourseDTO().InjectFrom(x)).ToList();
        }

        public CourseDTO GetCourseById(int id)
        {
            var courseToFind = courseRepository.Query(x => x.Id == id).FirstOrDefault();
            if (courseToFind != null)
            {
                return (CourseDTO)new CourseDTO().InjectFrom(courseToFind);
            }
            return new CourseDTO();
        }

        public bool UpdateCourse(CourseDTO course)
        {

            var userToUpdate = courseRepository.Query(x => x.Id == course.Id).FirstOrDefault();
            if (userToUpdate != null)
            {
                userToUpdate.InjectFrom(course);
                unitOfWork.Save();
                return true;
            }
            return false;
        }

        public bool DeleteCourse(int courseId)
        {
            var userToDelete = courseRepository.Query(x => x.Id == courseId).FirstOrDefault();
            if (userToDelete != null)
            {
                courseRepository.Delete(userToDelete);
                unitOfWork.Save();
                return true;
            }
            return false;
        }

        public List<CourseDTO> GetCoursesByUser(int userId)
        {
            var user = userRepository.Query(x => x.Id == userId).FirstOrDefault();
            return user.Courses.Select(x => (CourseDTO)new CourseDTO().InjectFrom(x.Course)).ToList();
        }
    }
}
