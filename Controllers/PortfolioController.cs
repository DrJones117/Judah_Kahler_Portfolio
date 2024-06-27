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
    [Route("/that_training_app")]
    public ViewResult TrainingApp()
    {
        return View("Training_App");
    }

}

