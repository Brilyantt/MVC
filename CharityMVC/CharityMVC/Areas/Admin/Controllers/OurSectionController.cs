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
    public IActionResult Index()
    {
        List<OurSection> sections = _service.OurSections();
        return View(sections);
    }
    [HttpGet]
    #region Create
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(OurSectionVM ourSection)
    {
        _service.Create(ourSection);
        return RedirectToAction(nameof(Index));
    }
    #endregion
}
