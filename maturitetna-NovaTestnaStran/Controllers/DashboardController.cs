using maturitetna_NovaTestnaStran.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace maturitetna_NovaTestnaStran.Controllers;

public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;
    //public IActionResult Index()
    //{
    //    return View();
    //}
    public DashboardController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IActionResult> Index()
    {
        var viewModel = new ModelView();
        
        string targetDomain = "MojaDomena1";
        
        viewModel.Servers = await _context.Servers
            .Where(server => server.Domain.Domain == targetDomain)
            .ToListAsync();

        return View(viewModel);
    }
}