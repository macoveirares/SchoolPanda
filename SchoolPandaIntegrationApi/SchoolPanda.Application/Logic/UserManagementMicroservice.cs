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

        public List<UserDto> GetUsers()
        {
            var users = new List<UserDto>();

            return users;
        }

        public List<RoleDto> GetRoles()
        {
            var roles = new List<RoleDto>();

            return roles;
        }

        public void CreateUser(UserDto user)
        {
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/addUser", new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(user)));
            var result = request.Result;
            //check status code
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}