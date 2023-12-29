using maturitetna_NovaTestnaStran.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using maturitetna_NovaTestnaStran.Models;

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
    }
}
