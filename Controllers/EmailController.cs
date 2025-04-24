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
        public async Task<IActionResult> SendEmail([FromBody] EmailDto request)
        { 
            // if (request == null)
            // {
            //     return BadRequest(new { success = false, message = "Email request is null." });
            // }
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                .SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
                .ToList();

                return BadRequest(new
                {
                    Message = "Validation failed",
                    Errors = errors
                });
            }

            try
            {
                await _emailService.SendEmail(request);
                return Ok(new { Message = "Thank you for your message!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred. Please try again later.");
                return StatusCode(500, new 
                { 
                    Message = "Failed to send email.",
                    Error = ex.Message
                });
            }
        }
    }
}
