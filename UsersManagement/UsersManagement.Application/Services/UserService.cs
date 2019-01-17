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
        void AddRole(RoleDto role);
        bool DeleteRole(int roleId);
        bool UpdateRole(RoleDto role);
        void AddAttendance(AttendanceDTO attendance);
        bool DeleteAttendance(int attendanceId);
        bool UpdateAttendance(AttendanceDTO attendance);
        List<AttendanceDTO> GetUserAttendances(int userId);
        List<AttendanceDTO> GetAttendancesByCourse(int courseId);
        List<AttendanceDTO> GetUserAttendancesByCourse(int userId, int courseId);
        int Login(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Course> courseRepository;
        private readonly IRepository<Role> roleRepository;
        private readonly IRepository<Attendance> attendanceRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IRepository<User> userRepository, IRepository<Course> courseRepository, IRepository<Role> roleRepository, IRepository<Attendance> attendanceRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.courseRepository = courseRepository;
            this.roleRepository = roleRepository;
            this.attendanceRepository = attendanceRepository;
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

        public List<RoleDto> GetRoles()
        {
            return roleRepository.Query().Select(x => (RoleDto)new RoleDto().InjectFrom(x)).ToList();
        }

        public void AddRole(RoleDto role)
        {
            roleRepository.Insert((Role)new Role().InjectFrom(role));
            unitOfWork.Save();
        }

        public bool DeleteRole(int roleId)
        {
            var roleToDelete = roleRepository.Query(x => x.Id == roleId).FirstOrDefault();
            if (roleToDelete != null)
            {
                roleRepository.Delete(roleToDelete);
                unitOfWork.Save();
                return true;
            }
            return false;
        }

        public bool UpdateRole(RoleDto role)
        {
            var roleToUpdate = roleRepository.Query(x => x.Id == role.Id).FirstOrDefault();
            if (roleToUpdate != null)
            {
                roleToUpdate.InjectFrom(role);
                unitOfWork.Save();
                return true;
            }
            return false;
        }

        public void AddAttendance(AttendanceDTO attendance)
        {
            attendanceRepository.Insert((Attendance)new Attendance().InjectFrom(attendance));
            unitOfWork.Save();
        }

        public bool DeleteAttendance(int attendanceId)
        {
            var attendanceToDelete = attendanceRepository.Query(x => x.Id == attendanceId).FirstOrDefault();
            if (attendanceToDelete != null)
            {
                attendanceRepository.Delete(attendanceToDelete);
                unitOfWork.Save();
                return true;
            }
            return false;
        }

        public bool UpdateAttendance(AttendanceDTO attendance)
        {
            var attendanceToUpdate = attendanceRepository.Query(x => x.Id == attendance.Id).FirstOrDefault();
            if (attendanceToUpdate != null)
            {
                attendanceRepository.InjectFrom(attendanceToUpdate);
                unitOfWork.Save();
                return true;
            }
            return false;
        }

        public List<AttendanceDTO> GetUserAttendances(int userId)
        {
            var user = userRepository.Query(x => x.Id == userId).FirstOrDefault();
            return user.StudentAttendances.Select(x => (AttendanceDTO)new AttendanceDTO().InjectFrom(x)).ToList();
        }

        public List<AttendanceDTO> GetAttendancesByCourse(int courseId)
        {
            return attendanceRepository.Query(x => x.CourseId == courseId).Select(x => (AttendanceDTO)new AttendanceDTO().InjectFrom(x)).ToList();
        }

        public List<AttendanceDTO> GetUserAttendancesByCourse(int userId, int courseId)
        {
            var user = userRepository.Query(x => x.Id == userId).FirstOrDefault();
            return user.StudentAttendances.Where(x => x.CourseId == courseId).Select(x => (AttendanceDTO)new AttendanceDTO().InjectFrom(x)).ToList();
        }

        public int Login(string username, string password)
        {
            var user = userRepository.Query(x => x.Username == username && x.Password == x.Password).FirstOrDefault();
            if (user != null)
            {
                return user.Id;
            }
            return 0;
        }
    }
}
