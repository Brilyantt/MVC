using GYMProject.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace GYMProject.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    private readonly AppDbContext _context;
    public DashboardController()
    {
        _context = new AppDbContext();
    }
    public IActionResult Index()
    {
        return View();
    }
}
