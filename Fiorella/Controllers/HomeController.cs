using Fiorella.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiorella.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Flower> flowers = new List<Flower>();

            Flower flower = new Flower()
            {
                Id = 1,
                Title = "Peony",
                Price = 10,
                ImgUrl = "shop-14-img.jpg"
            };

            Flower flower2 = new Flower()
            {
                Id = 2,
                Title = "Peony",
                Price = 20,
                ImgUrl = "shop-14-img.jpg"
            };

            Flower flower3 = new Flower()
            {
                Id = 3,
                Title = "Peony",
                Price = 25,
                ImgUrl = "shop-14-img.jpg"
            };
            
            flowers.Add(flower);
            flowers.Add(flower2);
            flowers.Add(flower3);


            return View(flowers);
        }
    }
}
