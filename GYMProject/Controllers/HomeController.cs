using GYMProject.Contexts;
using GYMProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace GYMProject.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController()
    {
        _context = new AppDbContext();
    }
    public IActionResult Index()
    {
        List<GymProgram> gymPrograms = _context.gymPrograms.ToList();
        return View(gymPrograms);
    }
}
