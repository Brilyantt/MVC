using Microsoft.AspNetCore.Mvc;
using Villa_MVC_Project.BL.Services;
using Villa_MVC_Project.BL.ViewModels;
using Villa_MVC_Project.DAL.Models;

namespace Villa_MVC_Project.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class VillaController : Controller
{
    private readonly VillaService _villaService;
    public VillaController(VillaService villaService)
    {
        _villaService = villaService;
    }
    public IActionResult Index()
    {
        List<Villa> villas = _villaService.Villas();
        return View(villas);
    }

    [HttpGet]
    public IActionResult Info(int id)
    {
        Villa villas = _villaService.GetVillaById(id);
        return View(villas);
    }

    #region Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(VillaVM villaVM)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Model de problem var");
        }

        _villaService.Create(villaVM);
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Update
    [HttpGet]
    public IActionResult Update(int id)
    {
        Villa villa = _villaService.GetVillaById(id);
        return View(villa);
    }
    [HttpPost]
    public IActionResult Update(int id, Villa villa)
    {
        _villaService.Update(id, villa);
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Delete

    [HttpGet]
    public IActionResult Delete(int id)
    {
        Villa villa = _villaService.GetVillaById(id);
        return View(villa);
    }

    [HttpPost]
    [ActionName("Delete")]

    public IActionResult DeleteVilla(int id)
    {
        _villaService.Delete(id);
        return RedirectToAction(nameof(Index));
    }


    #endregion


}
