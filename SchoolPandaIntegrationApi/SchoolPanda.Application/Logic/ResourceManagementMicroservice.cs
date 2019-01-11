using SchoolPanda.Application.DTO;
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
    }
}