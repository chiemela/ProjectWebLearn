using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FullStack.Data;
using FullStack.Models;

namespace FullStack.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
    public class ModulesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ModulesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Modules
        public async Task<IActionResult> Index()
        {
              return _context.NewModules != null ? 
                          View(await _context.NewModules.ToListAsync()) :
                          Problem("Entity set 'ApplicationDBContext.NewModules'  is null.");
        }

        // GET: Modules/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NewModules == null)
            {
                return NotFound();
            }

            var modules = await _context.NewModules
                .FirstOrDefaultAsync(m => m.ModulesID == id);
            if (modules == null)
            {
                return NotFound();
            }

            return View(modules);
        }

        // GET: Modules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModulesID,ModuleSpecification,ModuleTitle,ModuleLevel,CreditRating,School,TotalStudyHours,ModuleSummary,CreatedDateTime")] Modules modules)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modules);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modules);
        }

        // GET: Modules/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NewModules == null)
            {
                return NotFound();
            }

            var modules = await _context.NewModules.FindAsync(id);
            if (modules == null)
            {
                return NotFound();
            }
            return View(modules);
        }

        // POST: Modules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ModulesID,ModuleSpecification,ModuleTitle,ModuleLevel,CreditRating,School,TotalStudyHours,ModuleSummary,CreatedDateTime")] Modules modules)
        {
            if (id != modules.ModulesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modules);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModulesExists(modules.ModulesID))
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
            return View(modules);
        }

        // GET: Modules/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NewModules == null)
            {
                return NotFound();
            }

            var modules = await _context.NewModules
                .FirstOrDefaultAsync(m => m.ModulesID == id);
            if (modules == null)
            {
                return NotFound();
            }

            return View(modules);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NewModules == null)
            {
                return Problem("Entity set 'ApplicationDBContext.NewModules'  is null.");
            }
            var modules = await _context.NewModules.FindAsync(id);
            if (modules != null)
            {
                _context.NewModules.Remove(modules);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModulesExists(string id)
        {
          return (_context.NewModules?.Any(e => e.ModulesID == id)).GetValueOrDefault();
        }
    }
}
