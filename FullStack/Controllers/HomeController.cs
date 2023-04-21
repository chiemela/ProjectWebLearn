using FullStack.Data;
using FullStack.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FullStack.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDBContext _application;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext application)
        {
            _logger = logger;
            _application = application;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View(_application.Users.ToList());
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}