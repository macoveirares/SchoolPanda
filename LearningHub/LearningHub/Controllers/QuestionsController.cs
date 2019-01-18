using LearningHub.Application.Services;
using LearningHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;
using System.Collections.Generic;

namespace LearningHub.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsService _questionsService;

        public QuestionsController(IQuestionsService questionsService)
        {
            _questionsService = questionsService;
        }

        [HttpPost]
        [Route("/api/v1/addQuestion")]
        public ActionResult<HttpResponse> AddQuestion([FromBody] AddQuestionModel addQuestionModel) 
        {
            _questionsService.AddQuestion(addQuestionModel.Question, addQuestionModel.UserId, addQuestionModel.Type, addQuestionModel.AddressedTo);
            return Ok();
        }

        [HttpPost]
        [Route("/api/v1/getQuestions")]
        public ActionResult<List<QuestionModel>> GetQuestions([FromBody] GetQuestionsModel questionsModel)
        {
            var questions = _questionsService.GetQuestions(questionsModel.UserId, questionsModel.Type);
            var result = new List<QuestionModel>();
            foreach(var item in questions)
            {
                result.Add((QuestionModel)new QuestionModel().InjectFrom(item));
            }
            return result;
        }

        //for prof

        [HttpPost]
        [Route("/api/v1/answerQuestion")]
        public ActionResult<HttpResponse> AnswerQuestion([FromBody] AnswerQuestionModel answerModel)
        {
            _questionsService.AnswerQuestion(answerModel.Id, answerModel.Answer, answerModel.Type, answerModel.ProfId);
            return Ok();
        }

        [HttpPost]
        [Route("/api/v1/getPrivateQuestionsForProf")]
        public ActionResult<List<QuestionModel>> GetQuestions([FromBody] int addressedToId)
        {
            var questions = _questionsService.GetPrivatequestionsForProf(addressedToId);
            var result = new List<QuestionModel>();
            foreach (var item in questions)
            {
                result.Add((QuestionModel)new QuestionModel().InjectFrom(item));
            }
            return result;
        }
    }
}