using Microsoft.AspNetCore.Mvc;

namespace Judah_Kahler_Portfolio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<EmailController> _logger;

        public EmailController(IEmailService emailService, ILogger<EmailController> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }

        [HttpPost("send")]
        public IActionResult SendEmail([FromBody] EmailDto request)
        { 
            if (request == null)
            {
                return BadRequest(new { success = false, message = "Email request is null." });
            }

            try
            {
                _emailService.SendEmail(request);
                _logger.LogInformation("Email sent!");
                return Ok(new { success = true, message = "Email sent successfully!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred. Please try again later.");
                return StatusCode(500, new { success = false, message = $"Internal server error: {ex.Message}" });
            }
        }
    }
}
