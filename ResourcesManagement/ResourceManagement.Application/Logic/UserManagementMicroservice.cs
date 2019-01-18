using ResourceManagement.Application.DTO;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ResourceManagement.Application.Logic
{
    public class UserManagementMicroservice
    {
        private readonly string baseUSerManagementMicroserviceUrl = "http://localhost:51677";
        private readonly HttpClient _httpClient;

        public UserManagementMicroservice(string baseUerManagementServiceUrl = null)
        {
            if (!string.IsNullOrEmpty(baseUerManagementServiceUrl))
                baseUSerManagementMicroserviceUrl = baseUerManagementServiceUrl;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void GetUser(int id)
        {

        }

        public List<CoursesDto> GetCourseByUser(int userId)
        {
            var courses = new List<CoursesDto>();
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/getCoursesByUser", 
                new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(userId), Encoding.UTF8, "application/json"));
            var response = request.Result.Content.ReadAsStringAsync().Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<CoursesDto>>(response);
        }
    }
}