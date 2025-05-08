using Fiorella.Contexts;
using Fiorella.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiorella.Areas.Admin.Controllers;

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
        List<Flower> flowers = _context.Flowers.ToList();
        return View(flowers);
    }
}
