using Microsoft.AspNetCore.Mvc;
using NFT_MVCProject.DAL.Contexts;
using NFT_MVCProject.DAL.Models;

namespace NFT_MVCProject.MVC.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        List<CollectionsMarket> collections = _context.CollectionsMarkets.ToList();
        return View(collections);
    }
}
