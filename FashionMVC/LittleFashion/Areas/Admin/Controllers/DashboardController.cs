using LittleFashion.Services;
using Microsoft.AspNetCore.Mvc;

namespace LittleFashion.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly ProductService _service;
        public DashboardController()
        {
            _service = new ProductService();
        }
        public IActionResult Index()
        {
            return View(_service.GetAllProducts());
        }
    }
}
