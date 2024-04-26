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

   public IActionResult Index()
    {
        return View();
    }

    // Muestra la vista para seleccionar el tipo de usuario
    [HttpGet]
    public async Task<IActionResult> SelectTypeUser()
    {
        var typeUsers = await _logger.Type_Users.ToListAsync();
        return View(typeUsers);
    }

    // Redirección al método Shift después de seleccionar un tipo de usuario

    // Muestra la vista de turnos utilizando el tipo de usuario seleccionado
    [HttpGet]
    public IActionResult Shift()
    {
        int typeUserId = 0;
        if (TempData["Type_Users"] != null)
        {
            typeUserId = Convert.ToInt32(TempData["Type_Users"]);
        }
        ViewBag.Type_Users = typeUserId;
        return View();
    }

// Muestra vista Type_Procedure
       public async Task<IActionResult> Type_Procedures()
    {
        return View(await _logger.Type_Procedures.ToListAsync());
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
