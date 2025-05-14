using CarMVC.Contexts;
using CarMVC.Models;
using CarMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarMVC.Controllers;

public class HomeController : Controller
{
    private readonly FeaturedCarService _featuredCarService;
    public HomeController()
    {
        _featuredCarService = new FeaturedCarService();
    }
    public IActionResult Index()
    {
        List<FeaturedCar> featuredCars = _featuredCarService.GetAllFeaturedCars();
        return View(featuredCars);
    }
}
