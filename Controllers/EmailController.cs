using Microsoft.AspNetCore.Mvc;

namespace Judah_Kahler_Portfolio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase{
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send")]
        public IActionResult SendEmail([FromBody] EmailDto request)
        {
            Console.WriteLine("Backend Function called" + "Email: " + request.From + " Subject: " + request.Subject + "Message: " + request.Body);
            try
            {
                _emailService.SendEmail(request);
                return StatusCode(200, "Message Sent!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}