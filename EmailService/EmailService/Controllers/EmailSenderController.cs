using EmailService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SendServiceApi;

namespace EmailService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSenderController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmailSenderController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        [HttpPost]
        [Route("/api/v1/sendEmail")]
        public void SendEmail([FromBody]EmailModel emailModel)
        {
            string url = _configuration["Email:EmailSendServiceBaseURL"];
            string username = _configuration["Email:EmailSendServiceUsername"];
            string password = _configuration["Email:EmailSendServicePassword"];

            var service = new SendService(username, password, url);

            var status = service.SendEmail("andrei.ciornei@outlook.com", "CloudXdb", emailModel.EmailTo,emailModel.Subject,emailModel.Content);
        }
    }
}