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
    public class DomainController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DomainController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Domain
        public async Task<IActionResult> Index()
        {
              return _context.Domain != null ? 
                          View(await _context.Domain.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Domain'  is null.");
        }

        // GET: Domain/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Domain == null)
            {
                return NotFound();
            }

            var domainEntity = await _context.Domain
                .FirstOrDefaultAsync(m => m.Id == id);
            if (domainEntity == null)
            {
                return NotFound();
            }

            return View(domainEntity);
        }

        // GET: Domain/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Domain/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Domain")] DomainEntity domainEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(domainEntity);
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
            return View(domainEntity);
        }

        // GET: Domain/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Domain == null)
            {
                return NotFound();
            }

            var domainEntity = await _context.Domain.FindAsync(id);
            if (domainEntity == null)
            {
                return NotFound();
            }
            return View(domainEntity);
        }

        // POST: Domain/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Domain")] DomainEntity domainEntity)
        {
            if (id != domainEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(domainEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DomainEntityExists(domainEntity.Id))
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
            return View(domainEntity);
        }

        // GET: Domain/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Domain == null)
            {
                return NotFound();
            }

            var domainEntity = await _context.Domain
                .FirstOrDefaultAsync(m => m.Id == id);
            if (domainEntity == null)
            {
                return NotFound();
            }

            return View(domainEntity);
        }

        // POST: Domain/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Domain == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Domain'  is null.");
            }
            var domainEntity = await _context.Domain.FindAsync(id);
            if (domainEntity != null)
            {
                _context.Domain.Remove(domainEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DomainEntityExists(int id)
        {
          return (_context.Domain?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
