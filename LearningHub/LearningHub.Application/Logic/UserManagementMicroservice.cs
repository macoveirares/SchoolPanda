using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace LearningHub.Application.Logic
{
    public class UserManagementMicroservice
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

        public void GetCourseByUser(int userId)
        {
            //var courses = new List<CoursesDto>();

            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/getUser",
                new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(userId), Encoding.UTF8, "application/json"));
            var response = request.Result.Content.ReadAsStringAsync().Result;

            //return Newtonsoft.Json.JsonConvert.DeserializeObject<List<CoursesDto>>(response);
        }
    }
}