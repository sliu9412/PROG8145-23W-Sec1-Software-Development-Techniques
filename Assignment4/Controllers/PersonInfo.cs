using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using assignment4.Models;

namespace assignment4.Controllers;

public class PersonInfoController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public PersonInfoController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(Person person)
    {
        return RedirectToAction("Person", person);
    }

    public IActionResult Person(Person person)
    {
        return View(person);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
