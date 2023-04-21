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
    public class UserModuleController : Controller
    {
        private readonly ApplicationDBContext _context;

        public UserModuleController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: UserModule
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.NewUserModule.Include(u => u.Enrollment).Include(u => u.Modules);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: UserModule/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NewUserModule == null)
            {
                return NotFound();
            }

            var userModule = await _context.NewUserModule
                .Include(u => u.Enrollment)
                .Include(u => u.Modules)
                .FirstOrDefaultAsync(m => m.UserModulesID == id);
            if (userModule == null)
            {
                return NotFound();
            }

            return View(userModule);
        }

        // GET: UserModule/Create
        public IActionResult Create()
        {
            ViewData["EnrollmentID"] = new SelectList(_context.Enrollment, "EnrollmentID", "EnrollmentID");
            ViewData["ModulesID"] = new SelectList(_context.NewModules, "ModulesID", "ModulesID");
            return View();
        }

        // POST: UserModule/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserModulesID,ModulesID,EnrollmentID")] UserModule userModule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userModule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnrollmentID"] = new SelectList(_context.Enrollment, "EnrollmentID", "EnrollmentID", userModule.EnrollmentID);
            ViewData["ModulesID"] = new SelectList(_context.NewModules, "ModulesID", "ModulesID", userModule.ModulesID);
            return View(userModule);
        }

        // GET: UserModule/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NewUserModule == null)
            {
                return NotFound();
            }

            var userModule = await _context.NewUserModule.FindAsync(id);
            if (userModule == null)
            {
                return NotFound();
            }
            ViewData["EnrollmentID"] = new SelectList(_context.Enrollment, "EnrollmentID", "EnrollmentID", userModule.EnrollmentID);
            ViewData["ModulesID"] = new SelectList(_context.NewModules, "ModulesID", "ModulesID", userModule.ModulesID);
            return View(userModule);
        }

        // POST: UserModule/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserModulesID,ModulesID,EnrollmentID")] UserModule userModule)
        {
            if (id != userModule.UserModulesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userModule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModuleExists(userModule.UserModulesID))
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
            ViewData["EnrollmentID"] = new SelectList(_context.Enrollment, "EnrollmentID", "EnrollmentID", userModule.EnrollmentID);
            ViewData["ModulesID"] = new SelectList(_context.NewModules, "ModulesID", "ModulesID", userModule.ModulesID);
            return View(userModule);
        }

        // GET: UserModule/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NewUserModule == null)
            {
                return NotFound();
            }

            var userModule = await _context.NewUserModule
                .Include(u => u.Enrollment)
                .Include(u => u.Modules)
                .FirstOrDefaultAsync(m => m.UserModulesID == id);
            if (userModule == null)
            {
                return NotFound();
            }

            return View(userModule);
        }

        // POST: UserModule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NewUserModule == null)
            {
                return Problem("Entity set 'ApplicationDBContext.NewUserModule'  is null.");
            }
            var userModule = await _context.NewUserModule.FindAsync(id);
            if (userModule != null)
            {
                _context.NewUserModule.Remove(userModule);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserModuleExists(int id)
        {
          return (_context.NewUserModule?.Any(e => e.UserModulesID == id)).GetValueOrDefault();
        }
    }
}
