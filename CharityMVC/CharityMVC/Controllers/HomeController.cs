using CharityMVC.Contexts;
using CharityMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CharityMVC.Controllers;

public class HomeController : Controller
{
    private readonly OurSectionContext _context;
    public HomeController()
    {
        _context = new OurSectionContext();
    }
    public IActionResult Index()
    {
        List<OurSection> sections = _context.OurSections.ToList();
        return View(sections);
    }
}
