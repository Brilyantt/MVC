using Fiorella.Contexts;
using Fiorella.Models;
using Fiorella.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fiorella.Areas.Admin.Controllers;

[Area("Admin")]
public class FlowerController : Controller
{
    private readonly FlowerService _service;

    public FlowerController()
    {
        _service = new FlowerService();
    }
    [HttpGet]
    public IActionResult Index()
    {
        List<Flower> flowers = _service.GetAllFlowers();

        return View(flowers);
    }

   

    [HttpGet]

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Flower flower)
    {
        _service.CreateFlower(flower);
        return RedirectToAction(nameof(Index));
    }
}
