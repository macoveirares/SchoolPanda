using SchoolPanda.Application.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;

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
        }

        public void CreateUser(UserDto user)
        {
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/addUser", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(user)));
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
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/addRole", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(role)));
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

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}