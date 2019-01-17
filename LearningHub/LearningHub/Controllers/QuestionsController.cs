using LearningHub.Application.Services;
using LearningHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

            return Ok();
        }

        [HttpPost]
        [Route("/api/v1/getQuestions")]
        public ActionResult<QuestionModel> GetQuestions([FromBody] GetQuestionsModel questionsModel)
        {
            
        }
    }
}