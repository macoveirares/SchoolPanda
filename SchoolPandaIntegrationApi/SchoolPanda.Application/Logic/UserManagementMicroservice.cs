using SchoolPanda.Application.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace SchoolPanda.Application.Logic
{
    public class UserManagementMicroservice : IDisposable
    {
        private readonly string baseUSerManagementMicroserviceUrl = "";
        private readonly HttpClient _httpClient;

        public UserManagementMicroservice(string baseUerManagementServiceUrl = null)
        {
            if (!string.IsNullOrEmpty(baseUerManagementServiceUrl))
                baseUSerManagementMicroserviceUrl = baseUerManagementServiceUrl;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void CreateUser(UserDto user)
        {
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/addUser", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(user),
                Encoding.UTF8, "application/json"));
            var result = request.Result;
            //check status code
        }

        public void DeleteUser(int userId)
        {
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/deleteUser", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(userId)));
            var result = request.Result;
            //check status code
        }

        public void UpdateUser(UserDto user)
        {
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/updateUser", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(user)));
            var result = request.Result;
            //check status code
        }

        public void AddRole(RoleDto role)
        {
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/addRole", 
                new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(role), Encoding.UTF8, "application/json"));
            var result = request.Result;
            //check status code
        }

        public void DeleteRole(int roleId)
        {
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/deleteRole", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(roleId)));
            var result = request.Result;
            //check status code
        }

        public void UpdateRole(RoleDto role)
        {
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/updateRole", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(role)));
            var result = request.Result;
            //check status code
        }

        public void AddCourse(CourseDto course)
        {
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/addCourse", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json"));
            var result = request.Result;
            //check status code
        }

        public void DeleteCourse(int courseId)
        {
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/deleteCourse", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(courseId)));
            var result = request.Result;
            //check status code
        }

        public void UpdateCourse(CourseDto course)
        {
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/updateCourse", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(course)));
            var result = request.Result;
            //check status code
        }

        public List<UserDto> GetUsers()
        {
            var request = _httpClient.GetAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/getUsers");
            var result = request.Result;
            var usersList = result.Content.ReadAsStringAsync().Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserDto>>(usersList);
            //check status code
        }

        public List<RoleDto> GetRoles()
        {
            var request = _httpClient.GetAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/getRoles");
            var result = request.Result;
            var usersList = result.Content.ReadAsStringAsync().Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<RoleDto>>(usersList);
            //check status code
        }

        public List<CourseDto> GetCourses()
        {
            var request = _httpClient.GetAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/getCourses");
            var result = request.Result;
            var coursesList = result.Content.ReadAsStringAsync().Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<CourseDto>>(coursesList);
            //check status code
        }

        public List<MarkDto> GetUserMarks(int id)
        {
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/getUserMarks", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json"));
            var result = request.Result;
            var marksList = result.Content.ReadAsStringAsync().Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<MarkDto>>(marksList);
            //check status code
        }

        public List<AttendanceDto> GetUserAttendances(int id)
        {
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/getUserAttendances", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json"));
            var result = request.Result;
            var attendancesList = result.Content.ReadAsStringAsync().Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<AttendanceDto>>(attendancesList);
        }

        public List<CourseDto> GetUserCourses(int id)
        {
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/getCoursesByUser", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json"));
            var result = request.Result;
            var coursesList = result.Content.ReadAsStringAsync().Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<CourseDto>>(coursesList);
        }

        public void AddAttendance(AttendanceDto attendance)
        {
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/addAttendance", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(attendance), Encoding.UTF8, "application/json"));
            var result = request.Result;
            //check status code
        }

        public void AddMark(AddMarkDto mark)
        {
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/addMark", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(mark), Encoding.UTF8, "application/json"));
            var result = request.Result;
            //check status code
        }

        public void DeleteAttendance(int attendanceId)
        {
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/deleteAttendance", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(attendanceId)));
            var result = request.Result;
            //check status code
        }

        public void UpdateAttendance(AttendanceDto attendance)
        {
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/updateAttendance", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(attendance)));
            var result = request.Result;
            //check status code
        }

        public bool Login(string username, string password)
        {
            var login = new LoginDto() { Username = username, Password = password};
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/login", 
                new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json"));
            var result = request.Result;
            if (result.StatusCode == System.Net.HttpStatusCode.OK) return true;
            return false;
            //check status code
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}