using Microsoft.AspNetCore.Mvc;
using ScholarMVC.BL.Services;
using ScholarMVC.BL.ViewModels;
using ScholarMVC.DAL.Models;

namespace ScholarMVC.MVC.Areas.Admin.Controllers;
[Area("Admin")]

public class CourceController : Controller
{
    private readonly CourceService _sourceService;
    public CourceController(CourceService courceService)
    {
        _sourceService = courceService;
    }
    public IActionResult Index()
    {
        List<Cource> cources = _sourceService.Cources();
        return View(cources);
    }

    [HttpGet]
    public IActionResult Info(int id)
    {
        Cource cources = _sourceService.GetAllCourcesById(id);
        return View(cources);
    }

    #region Create

    [HttpGet]

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CourceVM cources)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        _sourceService.Create(cources);
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Update
    [HttpGet]

    public IActionResult Update(int id)
    {
        Cource cource = _sourceService.GetAllCourcesById(id);
        return View(cource);
    }

    [HttpPost]
    public IActionResult Update(int id, Cource cource)
    {
        _sourceService.Update(id, cource);
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Delete

    [HttpGet]
    public IActionResult Delete(int id)
    {
        Cource cource = _sourceService.GetAllCourcesById(id);
        return View(cource);
    }
    [HttpPost]
    [ActionName("Delete")]

    public IActionResult DeleteItem(int id)
    {
        _sourceService.Delete(id);
         return  RedirectToAction(nameof(Index));
    }
         


    #endregion
}
