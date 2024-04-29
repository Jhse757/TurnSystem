using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TurnSystem.Models;
using Microsoft.EntityFrameworkCore;
using TurnSystem.Data;

public class WindowController : Controller
{
    private readonly DataBaseContext _context;

    // Inyectar el contexto de base de datos a través del constructor
    public WindowController(DataBaseContext context)
    {
        _context = context;
    }

    // Acción Window para mostrar turnos en estado "Atendiendo"
    public async Task<IActionResult> Index()
    {
        // Obtener los turnos en estado "Atendiendo"
        var shifts = await _context.Shifts
            .Include(s => s.Adviser)
            .Include(s => s.User)
            .Include(s => s.Type_Procedure)
            .Include(s => s.Status)
            .Where(s => s.Status.description == "Espera")
            .ToListAsync();

        // Pasar los turnos a la vista
        return View(shifts);
    }
}
