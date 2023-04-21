using Microsoft.AspNetCore.Mvc;

namespace ProjectWebLearn.Controllers
{
    public class PrivacyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
