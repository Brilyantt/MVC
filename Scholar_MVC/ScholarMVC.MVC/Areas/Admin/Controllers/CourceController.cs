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
    public IActionResult Create(CourceVM courceVM)
    {
        if (!ModelState.IsValid)
        {
            return View(courceVM);
        }
        _sourceService.Create(courceVM);
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Create



    #endregion

    #region Create

    #endregion
}
