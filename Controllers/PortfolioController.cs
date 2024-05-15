using Microsoft.AspNetCore.Mvc;
namespace Judah_Kahler_Portfolio.Controllers;

public class PortfolioController : Controller
{
    private IEmailService _emailService;

    public PortfolioController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        EmailDto message = new EmailDto
        {
            To = "judah.kahler@gmail.com",
            Subject = "This is a test subject",
            Body = "This is a test message"
        };

        // _emailService.SendEmail(message);

        return View("Index");
    }


    // [HttpGet] 
    // [Route("")] 
    // public ViewResult Index()        
    // {            
    //     return View("Index");        
    // }   

    [HttpGet]
    [Route("/connect_four_details")]
    public ViewResult ConnectFour()
    {
        return View("Connect_Four");
    }

    [HttpGet]
    [Route("/that-training_app")]
    public ViewResult TrainingApp()
    {
        return View("Training_App");
    }

    // [HttpPost]
    // [Route("/sendEmail")]
    // public async Task<IActionResult> SendEmail(string email, string subject, string message)
    // {
    //     Console.WriteLine("triggered");

    //     // await _emailSender.SendEmailAsync(email, subject, message);

    //     return Redirect("/");
    // }

}

