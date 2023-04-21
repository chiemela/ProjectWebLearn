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
    public class UserModulesController : Controller
    {
        private readonly ApplicationDBContext _context;

        public UserModulesController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: UserModules
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.UserModules.Include(u => u.Enrollment).Include(u => u.Module);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: UserModules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserModules == null)
            {
                return NotFound();
            }

            var userModules = await _context.UserModules
                .Include(u => u.Enrollment)
                .Include(u => u.Module)
                .FirstOrDefaultAsync(m => m.UserModulesID == id);
            if (userModules == null)
            {
                return NotFound();
            }

            return View(userModules);
        }

        // GET: UserModules/Create
        public IActionResult Create()
        {
            ViewData["EnrollmentID"] = new SelectList(_context.Enrollment, "EnrollmentID", "EnrollmentID");
            ViewData["ModuleID"] = new SelectList(_context.Module, "ModuleID", "Code");
            return View();
        }

        // POST: UserModules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserModulesID,ModuleID,EnrollmentID")] UserModules userModules)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userModules);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnrollmentID"] = new SelectList(_context.Enrollment, "EnrollmentID", "EnrollmentID", userModules.EnrollmentID);
            ViewData["ModuleID"] = new SelectList(_context.Module, "ModuleID", "Code", userModules.ModuleID);
            return View(userModules);
        }

        // GET: UserModules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserModules == null)
            {
                return NotFound();
            }

            var userModules = await _context.UserModules.FindAsync(id);
            if (userModules == null)
            {
                return NotFound();
            }
            ViewData["EnrollmentID"] = new SelectList(_context.Enrollment, "EnrollmentID", "EnrollmentID", userModules.EnrollmentID);
            ViewData["ModuleID"] = new SelectList(_context.Module, "ModuleID", "Code", userModules.ModuleID);
            return View(userModules);
        }

        // POST: UserModules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserModulesID,ModuleID,EnrollmentID")] UserModules userModules)
        {
            if (id != userModules.UserModulesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userModules);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModulesExists(userModules.UserModulesID))
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
            ViewData["EnrollmentID"] = new SelectList(_context.Enrollment, "EnrollmentID", "EnrollmentID", userModules.EnrollmentID);
            ViewData["ModuleID"] = new SelectList(_context.Module, "ModuleID", "Code", userModules.ModuleID);
            return View(userModules);
        }

        // GET: UserModules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserModules == null)
            {
                return NotFound();
            }

            var userModules = await _context.UserModules
                .Include(u => u.Enrollment)
                .Include(u => u.Module)
                .FirstOrDefaultAsync(m => m.UserModulesID == id);
            if (userModules == null)
            {
                return NotFound();
            }

            return View(userModules);
        }

        // POST: UserModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserModules == null)
            {
                return Problem("Entity set 'ApplicationDBContext.UserModules'  is null.");
            }
            var userModules = await _context.UserModules.FindAsync(id);
            if (userModules != null)
            {
                _context.UserModules.Remove(userModules);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserModulesExists(int id)
        {
          return (_context.UserModules?.Any(e => e.UserModulesID == id)).GetValueOrDefault();
        }
    }
}
