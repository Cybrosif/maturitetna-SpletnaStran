using maturitetna_NovaTestnaStran.Data;
using Microsoft.AspNetCore.Mvc;

namespace maturitetna_NovaTestnaStran.Controllers;

public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;

    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IActionResult> Index(Guid? id)
    {
        return View();
    }
}