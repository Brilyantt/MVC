using Microsoft.AspNetCore.Mvc;
using Villa_MVC_Project.BL.Services;

namespace Villa_MVC_Project.MVC.Areas.Admin.Controllers;

public class DashboardController : Controller
{
    private readonly VillaService _villaService;
    public DashboardController(VillaService villaService)
    {
        _villaService = villaService;
    }
    public IActionResult Index()
    {
        return View();
    }
}
