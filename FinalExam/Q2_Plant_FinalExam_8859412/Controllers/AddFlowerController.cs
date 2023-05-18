// Siyu Liu 8859412
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Q2_Plant_FinalExam_8859412.Models;

namespace Q2_Plant_FinalExam_8859412.Controllers;

public class AddFlowerController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public AddFlowerController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        try { } catch { }
        return View();
    }

    [HttpPost]
    public IActionResult Index(Flower flower)
    {
        try { } catch { }
        return RedirectToAction("ThankYou", flower);
    }

    public IActionResult ThankYou(Flower flower)
    {
        try { } catch { }
        return View(flower);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
