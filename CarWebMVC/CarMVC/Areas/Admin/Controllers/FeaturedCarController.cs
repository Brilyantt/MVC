using CarMVC.Models;
using CarMVC.Services;
using CarMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarMVC.Areas.Admin.Controllers;
[Area("Admin")]
public class FeaturedCarController : Controller
{
    public readonly FeaturedCarService _featuredCarService;
    public FeaturedCarController()
    {
        _featuredCarService = new FeaturedCarService();
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<FeaturedCar> featuredCars = _featuredCarService.GetAllFeaturedCars();
        return View(featuredCars);
    }

    [HttpGet]
    public IActionResult Info(int id)
    {
       FeaturedCar featuredCars = _featuredCarService.GetFeaturedCarById(id);
        return View(featuredCars);
    }

    #region Create

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Create(FeaturedCarVM car)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("modelde sixinti var");
        }
        _featuredCarService.CreateFeaturedcar(car);
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Update

    [HttpGet]

    public IActionResult Update(int id)
    {
        FeaturedCar featuredCar = _featuredCarService.GetFeaturedCarById(id);
        return View(featuredCar);
    }

    [HttpPost]
    public IActionResult Update(int id, FeaturedCar featuredCar)
    {
        _featuredCarService.UpdateFeaturedCar(id, featuredCar);
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Delete
    [HttpGet]

    public IActionResult Delete(int id)
    {
        FeaturedCar featuredCar = _featuredCarService.GetFeaturedCarById(id);
        return View(featuredCar);
    }


    [HttpPost]

    [ActionName("Delete")]

    public IActionResult DeletePost(int id)
    {
        _featuredCarService.DeleteFeaturedCar(id);
        return RedirectToAction(nameof(Index));
    }

    #endregion
}
