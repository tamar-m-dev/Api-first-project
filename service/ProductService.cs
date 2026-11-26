using entiti;
using repository;

namespace service
{
    public class ProductService : IProductService
    {
        IProductRepository ProductRepository;
        public ProductService(IProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }
        public async Task<(List<Product> products, int total)> GetProducts(string? description, int minPrice, int maxPrice, int[] categoryIds, int position, int skip)
        {
            return await ProductRepository.GetProducts(description, minPrice, maxPrice, categoryIds, position, skip);
        }
    }
}
