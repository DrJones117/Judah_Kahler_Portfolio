using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
namespace Judah_Kahler_Portfolio.Controllers;

public class PortfolioController : Controller
{
    private IEmailService _emailService;

    public PortfolioController(IEmailService emailService)
    {
        _emailService = emailService;
    }
    // private readonly IEmailSender _emailSender;

    // public PortfolioController(IEmailSender emailSender)
    // {
    //     this._emailSender = emailSender;
    // }

    // [HttpGet]
    // [Route("")]
    // public async Task<IActionResult> Index()
    // {
    //     var receiver = "judah.kahler@gmail.com";
    //     var subject = "Test";
    //     var message = "Hello World";

    //     await _emailSender.SendEmailAsync(receiver, subject, message);

    //     return View("Index");
    // }

    // [HttpGet]
    // [Route("")]
    // public IActionResult Index()
    // {
    //     var email = new MimeMessage();
    //     email.From.Add(MailboxAddress.Parse("judah.kahler@gmail.com"));
    //     email.To.Add(MailboxAddress.Parse("judah.kahler@gmail.com"));
    //     email.Subject = "Test Email Subject";
    //     email.Body = new TextPart(TextFormat.Text) { Text = "This is a Test" };

    //     using var smtp = new SmtpClient();
    //     smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
    //     smtp.Authenticate("judah.kahler@gmail.com", "fgwu aneo isza vapw");
    //     smtp.Send(email);
    //     smtp.Disconnect(true);

    //     // return Ok();
    //     return View("Index"); 
    // }

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

        _emailService.SendEmail(message);

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

