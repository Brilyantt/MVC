using Microsoft.AspNetCore.Mvc;
using ScholarMVC.BL.Services;

namespace ScholarMVC.MVC.Areas.Admin.Controllers;
[Area("Admin")]
public class DashboardController : Controller
{

    private readonly CourceService _sourceService;
    public DashboardController(CourceService courceService)
    {
        _sourceService = courceService;
    }
    public IActionResult Index()
    {
        return View();
    }
}
