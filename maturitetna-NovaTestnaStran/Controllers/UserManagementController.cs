using maturitetna_NovaTestnaStran.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using maturitetna_NovaTestnaStran.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace maturitetna_NovaTestnaStran.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserManagementController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allUsers = _context.Users.ToListAsync();
            return View(await allUsers);
        }

        public IActionResult Create()
        {
            ViewData["DomainId"] = new SelectList(_context.Domain, "Id", "Domain");
            return View();
        }

        [HttpPost]
        [HttpPost]
        public IActionResult Create(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var newUser = new ApplicationUser
                    {
                        Email = model.Email,
                    };
                    
                }
                catch
                {
                    
                }
            }
            ViewData["DomainId"] = new SelectList(_context.Domain, "Id", "Domain");
            return View(model);
        }
    }
}
