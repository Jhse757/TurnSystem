using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TurnSystem.Models;
using TurnSystem.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;


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
public IActionResult Type_Users_Selected(string description, int? id)
    {
        TempData["Type_Users_Selected_id"] = id;
        TempData["Type_Users_Selected"] = description;
        TempData.Keep("Type_Users_Selected_id");        TempData["Type_Users_Selected"] = description;
        TempData.Keep("Type_Users_Selected");
        return RedirectToAction("Type_Procedures");
    }

// Muestra vista Type_Procedure
    public async Task<IActionResult> Type_Procedures(){
        return View(await _logger.Type_Procedures.ToListAsync());
    }
     //aqui se guarda que tipo de procedimiento requiere

[HttpPost]
public IActionResult Type_Procedures_Selected(string description, int? id)
{
    TempData["Type_Procedures_Selected_id"] = id;
    TempData.Keep("Type_Procedures_Selected_id");
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

    // Método para crear un nuevo turno y guardarlo en la base de datos
    [HttpPost]
    public async Task<IActionResult> NewShift(String Data)
    {
    // Obtiene los valores almacenados en TempData
    int? typeUserId = TempData["Type_Users_Selected_id"] as int?;
    int? typeProcedureId = TempData["Type_Procedures_Selected_id"] as int?;
    DateTime now = DateTime.Now;

    if (typeUserId != null || typeProcedureId != null)
    {
        // Si falta algún dato esencial, muestra un mensaje de error
        TempData["Error"] = "No se pudo obtener el tipo de usuario o el tipo de procedimiento.";
        return RedirectToAction("Shift");
    }

        // Crea una nueva instancia del modelo Shift
    Shift newShift = new Shift
    {
        user_id = typeUserId.Value,
        type_procedure_id = typeProcedureId.Value,
        status_id = 1,
        shift_date = now
    };

        // Agrega el nuevo turno al _logger y guarda los cambios
        _logger.Shifts.Add(newShift);
        await _logger.SaveChangesAsync();

        // Redirecciona a una vista o acción adecuada después de guardar
    return RedirectToAction("Index");

    }   
}



