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
        var shifts = await _context.Shifts
            .Include(s => s.User)
            .Include(s => s.Adviser)
            .Include(s => s.Type_Procedure)
            .Include(s => s.Status)
            .ToListAsync();

        return View(shifts);
    }
}
