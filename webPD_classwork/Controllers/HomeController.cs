using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using webPD_classwork.Models;


namespace webPD_classwork.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMyService _myService;

    public HomeController(ILogger<HomeController> logger, IMyService myService)
    {
        _logger = logger;
        _myService = myService;
    }

    public IActionResult Index()
    {
        try
        {
            string result = _myService.GetData();
            return View("Index", result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while getting data.");
            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
