using maturitetna_NovaTestnaStran.Data;
using maturitetna_NovaTestnaStran.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace maturitetna_NovaTestnaStran.Controllers
{
    public class ModelView
    {
        public List<ServerEntity> Servers { get; set; }
        public ServerEntity Server { get; set; }
    }
    public class ServersOverviewController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public ServersOverviewController(ApplicationDbContext context)
        {
            _context = context;
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

            viewModel.Servers = await _context.Servers.ToListAsync();

            return View(viewModel);
        }

    }
}
