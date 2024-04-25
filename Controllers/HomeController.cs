using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TurnSystem.Models;
using TurnSystem.Data;
using Microsoft.EntityFrameworkCore;


namespace TurnSystem.Controllers;

public class HomeController : Controller
{
    private readonly DataBaseContext _logger;

    public HomeController(DataBaseContext logger)
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

    // Muestra vista Type_users
    public async Task<IActionResult> Type_Users()
    
    {
    return View(await _logger.Type_Users.ToListAsync());
    }
    //aqui se guarda que tipo de usuario es
[HttpPost]
public IActionResult Type_Users_Selected(string description)
    {
        TempData["Type_Users_Selected"] = description;
        TempData.Keep("Type_Users_Selected");
        var Type_Users_Selected = new SelectedData();
        return RedirectToAction("Type_Procedures");
    }

// Muestra vista Type_Procedure
    public async Task<IActionResult> Type_Procedures(){
        return View(await _logger.Type_Procedures.ToListAsync());
    }
     //aqui se guarda que tipo de procedimiento requiere

[HttpPost]
public IActionResult Type_Procedures_Selected(string description)
{
    TempData["Type_Procedures_Selected"] = description;
    TempData.Keep("Type_Procedures_Selected");
    return RedirectToAction("Shift");
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
