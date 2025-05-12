using Microsoft.AspNetCore.Mvc;

namespace CarMVC.Areas.Area.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
