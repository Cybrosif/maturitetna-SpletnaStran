using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using maturitetna_NovaTestnaStran.Data;
using maturitetna_NovaTestnaStran.Models;

namespace maturitetna_NovaTestnaStran.Controllers
{
    public class ServerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Server
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Servers.Include(s => s.Domain);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Server/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Servers == null)
            {
                return NotFound();
            }

            var serverEntity = await _context.Servers
                .Include(s => s.Domain)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serverEntity == null)
            {
                return NotFound();
            }

            return View(serverEntity);
        }

        // GET: Server/Create
        public IActionResult Create()
        {
            ViewData["DomainId"] = new SelectList(_context.Domain, "Id", "Domain");

            return View();
        }

        // POST: Server/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DomainId,ServerName,Domain")] ServerEntity serverEntity)
        {
            serverEntity.Domain = _context.Domain.Find(serverEntity.DomainId);

            if (ModelState.IsValid && serverEntity.Domain != null)
            {
                _context.Add(serverEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                Console.WriteLine("Invalid ModelState. Validation errors:");

                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        Console.WriteLine($"- {error.ErrorMessage}");
                    }
                }
            }
            ViewData["DomainId"] = new SelectList(_context.Domain, "Id", "Domain", serverEntity.DomainId);
            return View(serverEntity);
        }

        // GET: Server/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Servers == null)
            {
                return NotFound();
            }

            var serverEntity = await _context.Servers.FindAsync(id);
            if (serverEntity == null)
            {
                return NotFound();
            }
            ViewData["DomainId"] = new SelectList(_context.Domain, "Id", "Domain", serverEntity.DomainId);
            return View(serverEntity);
        }

        // POST: Server/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,DomainId,ServerName")] ServerEntity serverEntity)
        {
            if (id != serverEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serverEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServerEntityExists(serverEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DomainId"] = new SelectList(_context.Domain, "Id", "Domain", serverEntity.DomainId);
            return View(serverEntity);
        }

        // GET: Server/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Servers == null)
            {
                return NotFound();
            }

            var serverEntity = await _context.Servers
                .Include(s => s.Domain)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serverEntity == null)
            {
                return NotFound();
            }

            return View(serverEntity);
        }

        // POST: Server/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Servers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Servers'  is null.");
            }
            var serverEntity = await _context.Servers.FindAsync(id);
            if (serverEntity != null)
            {
                _context.Servers.Remove(serverEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServerEntityExists(Guid id)
        {
          return (_context.Servers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
