using CharityMVC.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace CharityMVC.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    private readonly OurSectionContext _context;

    public DashboardController()
    {
        _context = new OurSectionContext();
    }
    public IActionResult Index()
    {
        return View();
    }
}
