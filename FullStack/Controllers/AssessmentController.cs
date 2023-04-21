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
    public class AssessmentController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AssessmentController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Assessment
        public async Task<IActionResult> Index()
        {
            var applicationDBContext = _context.Assessment.Include(a => a.UserModules);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: Assessment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Assessment == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessment
                .Include(a => a.UserModules)
                .FirstOrDefaultAsync(m => m.AssessmentID == id);
            if (assessment == null)
            {
                return NotFound();
            }

            return View(assessment);
        }

        // GET: Assessment/Create
        public IActionResult Create()
        {
            ViewData["UserModulesID"] = new SelectList(_context.UserModules, "UserModulesID", "UserModulesID");
            return View();
        }

        // POST: Assessment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssessmentID,UserModulesID,StudentEmail,LecturerEmailID,Grade,FileName,CreatedDateTime")] Assessment assessment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assessment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserModulesID"] = new SelectList(_context.UserModules, "UserModulesID", "UserModulesID", assessment.UserModulesID);
            return View(assessment);
        }

        // GET: Assessment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Assessment == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessment.FindAsync(id);
            if (assessment == null)
            {
                return NotFound();
            }
            ViewData["UserModulesID"] = new SelectList(_context.UserModules, "UserModulesID", "UserModulesID", assessment.UserModulesID);
            return View(assessment);
        }

        // POST: Assessment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssessmentID,UserModulesID,StudentEmail,LecturerEmailID,Grade,FileName,CreatedDateTime")] Assessment assessment)
        {
            if (id != assessment.AssessmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assessment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssessmentExists(assessment.AssessmentID))
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
            ViewData["UserModulesID"] = new SelectList(_context.UserModules, "UserModulesID", "UserModulesID", assessment.UserModulesID);
            return View(assessment);
        }

        // GET: Assessment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Assessment == null)
            {
                return NotFound();
            }

            var assessment = await _context.Assessment
                .Include(a => a.UserModules)
                .FirstOrDefaultAsync(m => m.AssessmentID == id);
            if (assessment == null)
            {
                return NotFound();
            }

            return View(assessment);
        }

        // POST: Assessment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Assessment == null)
            {
                return Problem("Entity set 'ApplicationDBContext.Assessment'  is null.");
            }
            var assessment = await _context.Assessment.FindAsync(id);
            if (assessment != null)
            {
                _context.Assessment.Remove(assessment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssessmentExists(int id)
        {
          return (_context.Assessment?.Any(e => e.AssessmentID == id)).GetValueOrDefault();
        }
    }
}
