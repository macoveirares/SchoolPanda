using System.Collections.Generic;
using System.Linq;
using UsersManagement.Data.Infrastructure;

namespace UsersManagement.Application.Services
{
    public interface IUsersToCourses
    {
        List<int> GetUsersToCourses(int userId);
    }

    class UsersToCourses : IUsersToCourses
    {
        private readonly IRepository<Domain.Entities.UserToCourse> _userToCoursesRepository;

        public UsersToCourses(IRepository<Domain.Entities.UserToCourse> userToCoursesRepository)
        {
            _userToCoursesRepository = userToCoursesRepository;
        }

        public List<int> GetUsersToCourses(int userId)
        {
            var entities = _userToCoursesRepository.Query(a => a.UserId == userId).Select(a=> a.CourseId).ToList();
            return entities;
        }
    }
}