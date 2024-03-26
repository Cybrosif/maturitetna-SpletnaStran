using maturitetna_NovaTestnaStran.Data;
using maturitetna_NovaTestnaStran.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace maturitetna_NovaTestnaStran.Controllers
{
    public class ModelView
    {
        public List<ServerEntity> Servers { get; set; }
        public ServerEntity Server { get; set; }
        
        public string Domain { get; set; }
    }
    public class ServersOverviewController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public ServersOverviewController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(Guid? id)
        {
            var viewModel = new ModelView();

            if (!id.HasValue)
            {
                viewModel.Server = await _context.Servers.FirstOrDefaultAsync();
            }
            else
            {
                // Get the server specified by id
                viewModel.Server = await _context.Servers.FirstOrDefaultAsync(s => s.Id == id);
            }

            //string targetDomain = "MojaDomena1";
            string targetDomain = await getUserDomain();
        
            viewModel.Servers = await _context.Servers
                .Where(server => server.Domain.Domain == targetDomain)
                .ToListAsync();

            viewModel.Domain = targetDomain;
            
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
}
