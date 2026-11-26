using entiti;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    public class ProductRepository : IProductRepository
    {
        my_shopContext _context;
        public ProductRepository(my_shopContext _context)
        {
            this._context = _context;
        }
        public async Task<(List<Product> products, int total)> GetProducts(string? description, int minPrice, int maxPrice, int[] categoryIds, int position, int skip)
        {
            var query = _context.Products.Where(product =>
            (description == null ? (true) : (product.Description.Contains(description)))
          && ((minPrice == null) ? (true) : (product.Price >= minPrice))
          && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
          && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
             .OrderBy(product => product.Price);
            List<Product> products = await query.Skip((position-1)*skip)
                .Take(skip).Include(p => p.Category).ToListAsync();
            var total = await query.CountAsync();
            return (products, total);
        }
    }
}
