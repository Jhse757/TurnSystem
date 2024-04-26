using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TurnSystem.Models;
using Microsoft.EntityFrameworkCore;
using TurnSystem.Data;

public class DashboardController : Controller
{
    public readonly DataBaseContext _context;

    public DashboardController(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
{
    // Obtener todos los turnos
    var shifts = await _context.Shifts
        .Include(s => s.User)
        .Include(s => s.Adviser)
        .Include(s => s.Type_Procedure)
        .Include(s => s.Status)
        .ToListAsync();

    // Obtener el primer turno (por ejemplo, el más próximo en términos de fecha)
    var firstShift = await _context.Shifts
        .Include(s => s.User)
        .Include(s => s.Adviser)
        .Include(s => s.Type_Procedure)
        .Include(s => s.Status)
        .OrderBy(s => s.shift_date) // Ordenar por fecha del turno
        .FirstOrDefaultAsync(); // Obtener el primer turno

    // Pasar ambos resultados a la vista
    ViewData["FirstShift"] = firstShift;

    return View(shifts);
}

}
