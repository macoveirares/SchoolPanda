using SchoolPanda.Application.DTO;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace SchoolPanda.Application.Logic
{
    public class ResourceManagementMicroservice
    {
        private readonly string baseUSerManagementMicroserviceUrl = "";
        private readonly HttpClient _httpClient;

        public ResourceManagementMicroservice(string baseUerManagementServiceUrl = null)
        {
            if (!string.IsNullOrEmpty(baseUerManagementServiceUrl))
                baseUSerManagementMicroserviceUrl = baseUerManagementServiceUrl;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ResourceDto GetResource(int id)
        {
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/getresource", 
                                new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json"));
            var result = request.Result;
            var resource = result.Content.ReadAsStringAsync().Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<ResourceDto>(resource);
        }

        public List<ResourceDto> GetAllLabs(int userId)
        {
            var resourceInfo = new ResourceInfo() { UserId = userId };
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/getallLabs",
                               new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(resourceInfo), Encoding.UTF8, "application/json"));
            var result = request.Result;
            var resource = result.Content.ReadAsStringAsync().Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResourceDto>>(resource);
        }

        public List<ResourceDto> GetCourseResources(int userId, int courseId)
        {
            var resourceInfo = new ResourceInfo() { UserId = userId, CourseId = courseId };
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/getCourseResource",
                               new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(resourceInfo), Encoding.UTF8, "application/json"));
            var result = request.Result;
            var resource = result.Content.ReadAsStringAsync().Result;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResourceDto>>(resource);
        }
    }
}