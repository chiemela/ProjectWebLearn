using Microsoft.AspNetCore.Mvc;

namespace ProjectWebLearn.Controllers
{
    public class TermsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
