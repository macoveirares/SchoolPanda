using SchoolPanda.Application.DTO;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace SchoolPanda.Application.Logic
{
    public class LearningHubMicroservice
    {
        private readonly string baseUSerManagementMicroserviceUrl = "";
        private readonly HttpClient _httpClient;

        public LearningHubMicroservice(string baseUerManagementServiceUrl = null)
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

        public void AddQuestion(string question, int userId, int type, int addressedTo)
        {
            var addQuestionDto = new DTO.AddQuestion()
            {
                Question = question,
                UserId = userId,
                Type = type,
                AddressedTo = addressedTo
            };

            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/addQuestion",
               new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(addQuestionDto), Encoding.UTF8, "application/json"));
            var response = request.Result;
        }

        public List<GetQestionsDto> GetQuestions(int userId, int type)
        {
            var getQuestionModel = new GetQestionsDto()
            {
                UserId = userId,
                Type = type
            };

            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/getQuestions",
             new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(getQuestionModel), Encoding.UTF8, "application/json"));
            var response = request.Result.Content.ReadAsStringAsync().Result;

            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<GetQestionsDto>>(response);
        }

        public List<GetQestionsDto> GetQuestionsForProf(int addressedTo)
        {
            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/getQuestions",
             new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(addressedTo), Encoding.UTF8, "application/json"));
            var response = request.Result.Content.ReadAsStringAsync().Result;

            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<GetQestionsDto>>(response);
        }

        public void AnswerQuestion(int Id, string answer, int type, int profId)
        {
            var dto = new AnswerQuestion()
            {
                Id = Id,
                Answer = answer,
                Type = type,
                ProfId = profId
            };

            var request = _httpClient.PostAsync($"{baseUSerManagementMicroserviceUrl}/api/v1/answerQuestion",
            new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json"));
            var response = request.Result;
        }
    }
}