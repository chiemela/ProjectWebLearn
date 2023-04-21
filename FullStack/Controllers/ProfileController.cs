using Microsoft.AspNetCore.Mvc;

namespace ProjectWebLearn.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
