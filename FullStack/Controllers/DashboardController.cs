using FullStack.Data;
using FullStack.Models;
using FullStack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using static NuGet.Packaging.PackagingConstants;

namespace FullStack.Controllers
{
    // this sets access levels
    [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin,Lecturer,Student")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDBContext _context;

        public DashboardController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var NewFeedbacks = _context.NewFeedbacks.ToList();
            var Notifications = _context.Notifications.ToList();
            var AttachmentFile = _context.AttachmentFile.ToList();
            var Enrollment = _context.Enrollment.ToList();
            var Tasks = _context.Tasks.ToList();
            var totalFeedbacks = NewFeedbacks.Count();
            var possibleGrades = totalFeedbacks * 100;
            var totalGrades = NewFeedbacks.Sum(x => x.Grade);
            var sumNotifications = Notifications.Count();
            var sumAttachmentFile = AttachmentFile.Count();
            var sumEnrollment = Enrollment.Count();
            var sumTasks = Tasks.Count();



        DashboardViewModel vm = new DashboardViewModel
            {
                FeedbacksVM = NewFeedbacks,
                SumNotifications = sumNotifications,
                SumAttachmentFile = sumAttachmentFile,
                SumEnrollment = sumEnrollment,
                SumTasks = sumTasks,
                TotalFeedbacks = totalFeedbacks,
                PossibleGrades = possibleGrades,
                TotalGrades = totalGrades
        };

            return View(vm);
        }
    }
}
