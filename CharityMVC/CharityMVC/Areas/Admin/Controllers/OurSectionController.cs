using CharityMVC.Models;
using CharityMVC.Services;
using CharityMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CharityMVC.Areas.Admin.Controllers;

[Area("Admin")]
public class OurSectionController : Controller
{
    private readonly OurSectionService _service;

    public OurSectionController()
    {
        _service = new OurSectionService();
    }
    [HttpGet]
    public IActionResult Index()
    {
        List<OurSection> sections = _service.OurSections();
        return View(sections);
    }

    [HttpGet]

    public IActionResult Info(int id)
    {
     
        OurSection ourSection = _service.GetOurSectionById(id);
        return View(ourSection);
    }
    
    #region Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(OurSectionVM ourSection)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("modelde sixinti var");
        }
        _service.Create(ourSection);
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Update
    [HttpGet]
    public IActionResult Update(int id)
    {
        OurSection ourSection = _service.GetOurSectionById(id);
        return View(ourSection);
    }

    [HttpPost]

    public IActionResult Update(int id, OurSection Section)
    {
        _service.Update(id, Section);
        return RedirectToAction(nameof(Index));
    }
    #endregion

    #region Delete
    [HttpGet]
    public IActionResult Delete(int id)
    {
       OurSection section = _service.GetOurSectionById(id);
        return View(section);
    }

    [HttpPost]

    [ActionName("Delete")]

    public IActionResult DeleteItem(int id)
    {
        _service.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    #endregion
}
