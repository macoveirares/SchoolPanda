using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Omu.ValueInjecter;
using SchoolPanda.Application.Logic;
using SchoolPandaIntegrationAPI.Models;

namespace SchoolPandaIntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QustionsController : ControllerBase
    {
        private readonly LearningHubMicroservice learningHubMicroservice;
        private readonly IConfiguration _configuration;

        public QustionsController(IConfiguration configuration)
        {
            _configuration = configuration;
            _configuration = configuration;
            var userManagementServiceUrl = _configuration["Microservices:LearningHubManagement"];
            learningHubMicroservice = string.IsNullOrEmpty(userManagementServiceUrl) ? new LearningHubMicroservice() : new LearningHubMicroservice(userManagementServiceUrl);
        }

        [HttpPost]
        [Route("/api/v1/addQuestion")]
        public ActionResult<HttpResponse> AddQuestion([FromBody] AddQuestionModel addQuestionModel)
        {
            learningHubMicroservice.AddQuestion(addQuestionModel.Question, addQuestionModel.UserId, addQuestionModel.Type, addQuestionModel.AddressedTo);
            return Ok();
        }

        [HttpPost]
        [Route("/api/v1/getQuestions")]
        public ActionResult<List<QuestionModel>> GetQuestions([FromBody] GetQuestionModel questionsModel)
        {
            var questions = learningHubMicroservice.GetQuestions(questionsModel.UserId, questionsModel.Type);

            var result = new List<QuestionModel>();
            foreach (var item in questions)
            {
                result.Add((QuestionModel)new QuestionModel().InjectFrom(item));
            }
            return result;
        }

        [HttpPost]
        [Route("/api/v1/getPrivateQuestionsForProf")]
        public ActionResult<List<QuestionModel>> GetQuestionsForProf([FromBody] int addressedTo)
        {
            var questions = learningHubMicroservice.GetQuestionsForProf(addressedTo);

            var result = new List<QuestionModel>();
            foreach (var item in questions)
            {
                result.Add((QuestionModel)new QuestionModel().InjectFrom(item));
            }
            return result;
        }

        [HttpPost]
        [Route("/api/v1/answerQuestion")]
        public ActionResult<HttpResponse> AnswerQuestion([FromBody] AnswerQuestionModel answerModel)
        {
            learningHubMicroservice.AnswerQuestion(answerModel.Id, answerModel.Answer, answerModel.Type, answerModel.ProfId);
            return Ok();
        }
    }
}