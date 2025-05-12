using CarMVC.Contexts;
using CarMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarMVC.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;
    public HomeController()
    {
        _context = new AppDbContext();
    }
    public IActionResult Index()
    {
        List<FeaturedCar> featuredCars = _context.featuredCars.ToList();
        return View(featuredCars);
    }
}
