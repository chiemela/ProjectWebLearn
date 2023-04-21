using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FullStack.Data;
using FullStack.Models;
using System.Net.Mail;
using System.Net;

namespace FullStack.Controllers
{
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin,Lecturer")]
    public class FeedbacksController : Controller
    {
        private readonly ApplicationDBContext _context;

        public FeedbacksController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Feedbacks
        public async Task<IActionResult> Index()
        {
            
            var applicationDBContext = _context.NewFeedbacks.Include(f => f.Modules);
            return View(await applicationDBContext.ToListAsync());
        }

        // GET: Feedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.NewFeedbacks == null)
            {
                return NotFound();
            }

            var feedbacks = await _context.NewFeedbacks
                .Include(f => f.Modules)
                .FirstOrDefaultAsync(m => m.FeedbacksID == id);
            if (feedbacks == null)
            {
                return NotFound();
            }

            return View(feedbacks);
        }

        // GET: Feedbacks/Create
        public IActionResult Create()
        {
            ViewData["ModulesID"] = new SelectList(_context.NewModules, "ModulesID", "ModulesID");
            return View();
        }

        // POST: Feedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeedbacksID,ModulesID,StudentEmailID,LecturerEmailID,Title,Grade,LecturerComment,CreatedDateTime")] Feedbacks feedbacks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedbacks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModulesID"] = new SelectList(_context.NewModules, "ModulesID", "ModulesID", feedbacks.ModulesID);

            // Create a new MailMessage object
            MailMessage message = new MailMessage();
            string? StudentEmailID = feedbacks.StudentEmailID;
            string? LecturerEmailID = feedbacks.LecturerEmailID;
            string? ModulesID = feedbacks.ModulesID;
            string? Title = feedbacks.Title;
            string? CreatedDateTime = feedbacks.CreatedDateTime.ToString();
            // Set the message properties
            message.From = new MailAddress(LecturerEmailID);
            message.To.Add(new MailAddress(StudentEmailID));
            message.Subject = "You have a new feedback for " + ModulesID;
            message.Body = "Module: " + ModulesID + "\nTitle: " + Title
                + "\nRelease Date: " + CreatedDateTime + ModulesID;

            // Create a new SmtpClient object and set its properties
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("example@gmail.com", "yourpassword");

            // Send the email
            client.Send(message);

            return View(feedbacks);
        }

        // GET: Feedbacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NewFeedbacks == null)
            {
                return NotFound();
            }

            var feedbacks = await _context.NewFeedbacks.FindAsync(id);
            if (feedbacks == null)
            {
                return NotFound();
            }
            ViewData["ModulesID"] = new SelectList(_context.NewModules, "ModulesID", "ModulesID", feedbacks.ModulesID);
            return View(feedbacks);
        }

        // POST: Feedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeedbacksID,ModulesID,StudentEmailID,LecturerEmailID,Title,Grade,LecturerComment,CreatedDateTime")] Feedbacks feedbacks)
        {
            if (id != feedbacks.FeedbacksID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedbacks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbacksExists(feedbacks.FeedbacksID))
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
            ViewData["ModulesID"] = new SelectList(_context.NewModules, "ModulesID", "ModulesID", feedbacks.ModulesID);
            return View(feedbacks);
        }

        // GET: Feedbacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NewFeedbacks == null)
            {
                return NotFound();
            }

            var feedbacks = await _context.NewFeedbacks
                .Include(f => f.Modules)
                .FirstOrDefaultAsync(m => m.FeedbacksID == id);
            if (feedbacks == null)
            {
                return NotFound();
            }

            return View(feedbacks);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NewFeedbacks == null)
            {
                return Problem("Entity set 'ApplicationDBContext.NewFeedbacks'  is null.");
            }
            var feedbacks = await _context.NewFeedbacks.FindAsync(id);
            if (feedbacks != null)
            {
                _context.NewFeedbacks.Remove(feedbacks);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbacksExists(int id)
        {
          return (_context.NewFeedbacks?.Any(e => e.FeedbacksID == id)).GetValueOrDefault();
        }
    }
}
