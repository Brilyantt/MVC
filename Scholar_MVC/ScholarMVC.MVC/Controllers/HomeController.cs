using Microsoft.AspNetCore.Mvc;
using ScholarMVC.BL.Services;
using ScholarMVC.DAL.Models;

namespace ScholarMVC.MVC.Controllers;

public class HomeController : Controller
{
    private readonly CourceService _sourceService;
    public HomeController(CourceService courceService)
    {
        _sourceService = courceService;
    }
    public IActionResult Index()
    {
        List<Cource> cources = _sourceService.Cources();
        return View(cources);
    }
}
