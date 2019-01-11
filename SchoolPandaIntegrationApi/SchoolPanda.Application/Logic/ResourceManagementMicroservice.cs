using System;
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
    }

    
}