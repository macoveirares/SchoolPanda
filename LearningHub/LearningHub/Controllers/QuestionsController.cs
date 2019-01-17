using LearningHub.Application.Services;
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
        public void AddQuestion()
        {

        }


    }
}