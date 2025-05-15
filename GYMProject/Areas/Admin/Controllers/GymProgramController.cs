using GYMProject.Models;
using GYMProject.Services;
using GYMProject.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GYMProject.Areas.Admin.Controllers;

[Area("Admin")]
public class GymProgramController : Controller
{
    private readonly GymProgramService _context;
    public GymProgramController()
    {
        _context = new GymProgramService();
    }
    [HttpGet]
    public IActionResult Index()
    {
        List<GymProgram> gymPrograms = _context.GymPrograms();
        return View(gymPrograms);
    }

    [HttpGet]

    public IActionResult Info(int id)
    {
        GymProgram gymProgram = _context.GetGymProgramById(id);
        return View(gymProgram);
    }

    #region Create
    [HttpGet]

    public IActionResult Create()
    {
        return View();

    }

    [HttpPost]

    public IActionResult Create(GymProgramVM gymProgram)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Modelde problem var");
        }
        _context.Create(gymProgram);
        return RedirectToAction(nameof(Index));

    }
    #endregion



    #region Update

    [HttpGet]
    public IActionResult Update(int id)
    {
        GymProgram gymProgram = _context.GetGymProgramById(id);
        return View(gymProgram);
    }

    [HttpPost]
    public IActionResult Update(int id, GymProgram gymProgram)
    {
        _context.Update(id, gymProgram);
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Delete

    [HttpGet]
    public IActionResult Delete(int id)
    {
        GymProgram gymProgram = _context.GetGymProgramById(id);
        return View(gymProgram);
    }
    [HttpPost]
    [ActionName("Delete")]

    public IActionResult DeleteGym(int id)
    {
        _context.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    #endregion
}
