using LittleFashion.Models;
using Microsoft.AspNetCore.Mvc;

namespace LittleFashion.Controllers;

public class HomeController : Controller
{
    private readonly FeaturedProduct _context;
    public HomeController()
    {
        _context = new FeaturedProduct();
    }
    public IActionResult Index()
    {
        List<FeaturedProduct> featuredProducts = new List<FeaturedProduct>();
        return View(featuredProducts);
    }
}
