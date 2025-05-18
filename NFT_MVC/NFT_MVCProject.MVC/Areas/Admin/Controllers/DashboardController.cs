using Microsoft.AspNetCore.Mvc;
using NFT_MVCProject.DAL.Contexts;

namespace NFT_MVCProject.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    private readonly AppDbContext _context;

    public DashboardController(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }
    public IActionResult Index()
    {
        return View();
    }
}
