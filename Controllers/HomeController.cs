using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TurnSystem.Models;
using TurnSystem.Data;

namespace TurnSystem.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

// Muestra vista Index

    // public async Task<IActionResult> Index()
    // {
    //     return View(await _logger.Type_Users.ToListAsync());
    // }

// Muestra vista Shift
   public IActionResult Shift()
    {
        return View();
    }


   public IActionResult Index()
    {
        return View();
    }

// Muestra vista Type_Procedure
       public IActionResult Type_Procedures()
    {
        return View();
    }

// Muestra vista Type_users
       public IActionResult Type_users()
    {
        return View();
    }

// Muestra vista Privacy
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
