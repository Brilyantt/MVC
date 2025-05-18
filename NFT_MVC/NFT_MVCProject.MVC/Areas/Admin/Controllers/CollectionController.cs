using Microsoft.AspNetCore.Mvc;
using NFT_MVCProject.BL.Services;
using NFT_MVCProject.DAL.Contexts;
using NFT_MVCProject.DAL.Models;
using NFT_MVCProject.MVC.ViewModels;

namespace NFT_MVCProject.MVC.Areas.Admin.Controllers;
[Area("Admin")]

public class CollectionController : Controller
{

    private readonly CollectionsMarketService  _collectionsMarketService;

    public CollectionController(CollectionsMarketService collectionsMarketService)
    {
       _collectionsMarketService = collectionsMarketService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        List<CollectionsMarket> collections = _collectionsMarketService.CollectionsMarkets();
        return View(collections);
    }


    [HttpGet]

    public IActionResult Info(int id)
    {
        CollectionsMarket collectionsMarket = _collectionsMarketService.GetCollectionsMarketById(id);
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
            return View();
        }
        _collectionsMarketService.Create(collections);

        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Update
    [HttpGet]
    public IActionResult Update(int id)
    {
        CollectionsMarket collectionsMarket = _collectionsMarketService.GetCollectionsMarketById(id);
        return View(collectionsMarket);
    }
    [HttpPost]
    public IActionResult Update(int id, CollectionsMarket collections)
    {
        _collectionsMarketService.Update(id, collections);
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Delete
    [HttpGet]
    public IActionResult Delete(int id)
    {
        CollectionsMarket collections = _collectionsMarketService.GetCollectionsMarketById(id);


        return View(collections);

    }
    [HttpPost]

    [ActionName("Delete")]

    public IActionResult DeleteItem(int id)
    {
        _collectionsMarketService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    #endregion
}
