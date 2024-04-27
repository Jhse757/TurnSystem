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

    [HttpPost]
    public async Task<IActionResult> DeleteFirstRecord()
    {
        // Obtener el primer registro de la base de datos
        var firstShift = await _context.Shifts.OrderBy(s => s.shift_date).FirstOrDefaultAsync();

        if (firstShift != null)
        {
            // Eliminar el primer registro
            _context.Shifts.Remove(firstShift);
            await _context.SaveChangesAsync();
        }

        // Redirigir de vuelta al Dashboard
        return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<IActionResult> CallFirstShift()
    {
        // Obtener el primer turno que está en proceso ordenado por la fecha
        var firstShift = await _context.Shifts
            .Include(s => s.Status)
            .Include(s => s.Adviser)
            .OrderBy(s => s.shift_date)
            .FirstOrDefaultAsync(s => s.Status.description == "En proceso");

        if (firstShift != null)
        {
            // Cambiar el estado del turno a "Atendiendo"
            firstShift.Status.description = "Atendiendo";

            // Asignar el módulo correspondiente al turno según el recepcionista
            if (firstShift.Adviser != null)
            {
                firstShift.Adviser.Modulo = firstShift.Adviser.Modulo; // Esto ya está definido en `Adviser`
            }

            // Guardar los cambios en la base de datos
            await _context.SaveChangesAsync();

            // Return the updated firstShift object
            return Ok(firstShift);
        }

        // If firstShift is null, return a NotFound response
        return NotFound();
    }



}
