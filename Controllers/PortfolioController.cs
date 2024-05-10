using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
namespace Judah_Kahler_Portfolio.Controllers;

public class PortfolioController : Controller
{
    private readonly IEmailSender _emailSender;

    public PortfolioController(IEmailSender emailSender)
    {
        this._emailSender = emailSender;
    }

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

    [HttpGet] 
    [Route("")] 
    public ViewResult Index()        
    {            
        return View("Index");        
    }   

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

    [HttpPost]
    [Route("/sendEmail")]
    public async Task<IActionResult> SendEmail(string email, string subject, string message)
    {

        await _emailSender.SendEmailAsync(email, subject, message);

        return Redirect("/");
    }

}

