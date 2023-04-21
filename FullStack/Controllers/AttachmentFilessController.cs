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
    public class AttachmentFilessController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AttachmentFilessController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: AttachmentFiless
        public async Task<IActionResult> Index()
        {
              return _context.AttachmentFile != null ? 
                          View(await _context.AttachmentFile.ToListAsync()) :
                          Problem("Entity set 'ApplicationDBContext.AttachmentFile'  is null.");
        }

        // GET: AttachmentFiless/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.AttachmentFile == null)
            {
                return NotFound();
            }

            var attachmentFile = await _context.AttachmentFile
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attachmentFile == null)
            {
                return NotFound();
            }

            return View(attachmentFile);
        }

        // GET: AttachmentFiless/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AttachmentFiless/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FilePath,ContentType,FileName,Grade,Length,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy,Cancelled")] AttachmentFile attachmentFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(attachmentFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(attachmentFile);
        }

        // GET: AttachmentFiless/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.AttachmentFile == null)
            {
                return NotFound();
            }

            var attachmentFile = await _context.AttachmentFile.FindAsync(id);
            if (attachmentFile == null)
            {
                return NotFound();
            }
            return View(attachmentFile);
        }

        // POST: AttachmentFiless/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,FilePath,ContentType,FileName,Grade,Length,CreatedDate,ModifiedDate,CreatedBy,ModifiedBy,Cancelled")] AttachmentFile attachmentFile)
        {
            if (id != attachmentFile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attachmentFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttachmentFileExists(attachmentFile.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index", "AttachmentFile");

            }
            return View(attachmentFile);
        }

        // GET: AttachmentFiless/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.AttachmentFile == null)
            {
                return NotFound();
            }

            var attachmentFile = await _context.AttachmentFile
                .FirstOrDefaultAsync(m => m.Id == id);
            if (attachmentFile == null)
            {
                return NotFound();
            }

            return View(attachmentFile);
        }

        // POST: AttachmentFiless/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.AttachmentFile == null)
            {
                return Problem("Entity set 'ApplicationDBContext.AttachmentFile'  is null.");
            }
            var attachmentFile = await _context.AttachmentFile.FindAsync(id);
            if (attachmentFile != null)
            {
                _context.AttachmentFile.Remove(attachmentFile);
            }
            
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToAction("Index", "AttachmentFile");
        }

        private bool AttachmentFileExists(long id)
        {
          return (_context.AttachmentFile?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
