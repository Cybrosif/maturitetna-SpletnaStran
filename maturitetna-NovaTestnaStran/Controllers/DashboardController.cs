using maturitetna_NovaTestnaStran.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace maturitetna_NovaTestnaStran.Controllers;

public class DashboardController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    //public IActionResult Index()
    //{
    //    return View();
    //}
    public DashboardController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
        _context = context;
    }
    
    public async Task<IActionResult> Index()
    {
        var viewModel = new ModelView();
        
        
        string targetDomain = await getUserDomain();
        viewModel.Domain = targetDomain;
        
        viewModel.Servers = await _context.Servers
            .Where(server => server.Domain.Domain == targetDomain)
            .ToListAsync();

        return View(viewModel);
    }

    private async Task<string?> getUserDomain()
    {
        IdentityUser user = await _userManager.GetUserAsync(User);
        string userId = user.Id;
        int domainId = await _context.UserDomain
            .Where(ud => ud.UserId == userId)
            .Select(ud => ud.DomainId)
            .FirstOrDefaultAsync();
        string domain = await _context.Domain
            .Where(d => d.Id == domainId)
            .Select(ud => ud.Domain)
            .FirstOrDefaultAsync();

        return domain;
    }
}