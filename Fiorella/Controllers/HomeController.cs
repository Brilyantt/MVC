using Microsoft.AspNetCore.Mvc;

namespace Fiorella.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
