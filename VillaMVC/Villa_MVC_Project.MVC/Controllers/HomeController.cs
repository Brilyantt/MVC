using Microsoft.AspNetCore.Mvc;
using Villa_MVC_Project.BL.Services;
using Villa_MVC_Project.DAL.Models;

namespace Villa_MVC_Project.MVC.Controllers;

public class HomeController : Controller
{
    private readonly VillaService _villaService;
    public HomeController(VillaService villaService)
    {
        _villaService = villaService;
    }
    public IActionResult Index()
    {
        List<Villa> villas = _villaService.Villas();
        return View(villas);
    }
}
