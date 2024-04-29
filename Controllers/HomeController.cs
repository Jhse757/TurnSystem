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
    //aqui se guarda que tipo de usuario es
[HttpPost]
public IActionResult Type_Users_Selected(string description, int id)
    {   
        TempData["Type_Users_Selected_id"] = id;
        TempData.Keep("Type_Users_Selected_id");
        TempData["Type_Users_Selected"] = description;
        TempData.Keep("Type_Users_Selected_id");       
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

public IActionResult Type_Document_Selected(string description, int? id)
{
    TempData["Type_Procedures_Selected_id"] = id;
    TempData.Keep("Type_Document_Selected_id");
    TempData["Type_Document_Selected"] = description;
    TempData.Keep("Type_Document_Selected");
    return RedirectToAction("Shift");
}

//controlador para vista de cedula y usuario
public async Task<IActionResult> Type_Documents(){
    return View( await _logger.Type_Documents.ToListAsync());
}

[HttpPost]
public IActionResult Type_Document_Selected(int? id, string document, string name)
    {   
        TempData["Type_Document_Selected_id"] = id;
        TempData.Keep("Type_Document_Selected_id");
        TempData["Type_Document_Selected"] = name;
        TempData.Keep("Type_Document_Selected");
        TempData["Document_Name"] = document;
        TempData.Keep("Document_Name");
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
    int? typeDocumentId = TempData["Type_Document_Selected_id"] as int?;
    string documentName = TempData["Document_Name"] as string;
    DateTime now = DateTime.Now;

    // if (!typeUserId.HasValue || !typeProcedureId.HasValue)
    // {
    //     TempData["Error"] = "No se pudo obtener el tipo de usuario o el tipo de procedimiento.";
    //     return RedirectToAction("Shift");
    // }

        // Crea una nueva instancia del modelo Shift
    Shift newShift = new Shift
    {
        user_id = typeUserId.Value,
        type_procedure_id = typeProcedureId.Value,
        shift_date = DateTime.Now,
        status_id = 1 
        documentName = documentName.Value,
    };

        // Agrega el nuevo turno al _logger y guarda los cambios
        _logger.Shifts.Add(newShift);
        await _logger.SaveChangesAsync();

        // Redirecciona a una vista o acción adecuada después de guardar
    return RedirectToAction("Index");
    }   
}



