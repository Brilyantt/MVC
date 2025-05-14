using LittleFashion.Contexts;
using LittleFashion.Models;

namespace LittleFashion.Services
{
    public class ProductService
    {
        private readonly FeaturedProductContext _context;

        public ProductService()
        {
            _context = new FeaturedProductContext();
        }

        public List<FeaturedProduct> GetAllProducts()
        {
            return _context.FeaturedProducts.ToList();
        }


    }
}
