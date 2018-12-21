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
        UserDTO GetUser(int id);

    }

    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
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

        public UserDTO GetUser(int id)
        {
            var userToFind = userRepository.Query(x => x.Id == id).FirstOrDefault();
            if (userToFind != null)
            {
                return (UserDTO)new UserDTO().InjectFrom(userToFind);
            }
            return new UserDTO();
        }
    }
}
