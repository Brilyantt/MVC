using Microsoft.AspNetCore.Mvc;
using NFT_MVCProject.DAL.Contexts;
using NFT_MVCProject.DAL.Models;
using NFT_MVCProject.MVC.ViewModels;

namespace NFT_MVCProject.MVC.Areas.Admin.Controllers;
[Area("Admin")]

public class CollectionController : Controller
{

    private readonly AppDbContext _context;

    public CollectionController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<CollectionsMarket> collections = _context.CollectionsMarkets.ToList();
        return View(collections);
    }


    [HttpGet]

    public IActionResult Info(int id)
    {
        CollectionsMarket collectionsMarket = _context.CollectionsMarkets.Find(id);
        return View(collectionsMarket);
    }
    #region Create
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]

    public IActionResult Create(CollectionsMarketVM collections)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("have issue in model state");
        }

        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Update
    [HttpGet]
    public IActionResult Update(int id)
    {
        CollectionsMarket collectionsMarket = _context.CollectionsMarkets.Find(id);
        return View(collectionsMarket);
    }
    [HttpPost]
    public IActionResult Update(int id, CollectionsMarket collections)
    {
        _context.Update(id, collections);
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Delete
    [HttpGet]
    public IActionResult Delete(int id)
    {
        CollectionsMarket collections = _context._context.CollectionsMarkets.Find(id);


        return View(collections);

    }
    [HttpPost]

    [ActionName("Delete")]

    public IActionResult DeleteItem(int id)
    {
        _context.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    #endregion
}
