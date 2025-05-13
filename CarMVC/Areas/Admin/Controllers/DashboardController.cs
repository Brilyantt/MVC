using CarMVC.Contexts;
using CarMVC.Models;
using CarMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarMVC.Areas.Area.Controllers;

[Area("Admin")]
public class DashboardController : Controller
{
    private readonly FeaturedCarService _featuredCarService;
    public DashboardController()
    {
        _featuredCarService = new FeaturedCarService();
    }
    public IActionResult Index()
    {

        return View();
    }
}
