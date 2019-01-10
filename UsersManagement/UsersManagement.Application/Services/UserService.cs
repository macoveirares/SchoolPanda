using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;
using UsersManagement.Application.DTO;
using UsersManagement.Data.Infrastructure;
using UsersManagement.Domain.Entities;

namespace UsersManagement.Application.Services
{
    public interface IUserService
    {
        void CreateUser(UserDTO user);
        List<UserDTO> GetAllUsers();
        UserDTO GetUserById(int userId);
        bool UpdateUser(UserDTO user);
        bool DeleteUser(int userId);
        List<UserDTO> GetUsersByCourse(int courseId);
        List<RoleDto> GetRoles();
    }

    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Course> courseRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IRepository<User> userRepository, IRepository<Course> courseRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.courseRepository = courseRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateUser(UserDTO user)
        {
            userRepository.Insert((User)new User().InjectFrom(user));
            unitOfWork.Save();
        }

        public List<UserDTO> GetAllUsers()
        {
            return userRepository.Query().Select(x => (UserDTO)new UserDTO().InjectFrom(x)).ToList();
        }

        public UserDTO GetUserById(int userId)
        {
            var userToFind = userRepository.Query(x => x.Id == userId).FirstOrDefault();
            if (userToFind != null)
            {
                return (UserDTO)new UserDTO().InjectFrom(userToFind);
            }
            return new UserDTO();
        }

        public bool UpdateUser(UserDTO user)
        {

            var userToUpdate = userRepository.Query(x => x.Id == user.Id).FirstOrDefault();
            if (userToUpdate != null)
            {
                userToUpdate.InjectFrom(user);
                unitOfWork.Save();
                return true;
            }
            return false;
        }

        public bool DeleteUser(int userId)
        {
            var userToDelete = userRepository.Query(x => x.Id == userId).FirstOrDefault();
            if (userToDelete != null)
            {
                userRepository.Delete(userToDelete);
                unitOfWork.Save();
                return true;
            }
            return false;
        }

        public List<UserDTO> GetUsersByCourse(int courseId)
        {
            var course = courseRepository.Query(x => x.Id == courseId).FirstOrDefault();
            return course.Users.Select(x => (UserDTO)new UserDTO().InjectFrom(x.User)).ToList();
        }

        //public List<RoleDto> GetRoles()
        //{
            
        //}
    }
}
