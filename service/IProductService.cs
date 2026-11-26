using entiti;

namespace service
{
    public interface IProductService
    {
        Task<(List<Product> products, int total)> GetProducts(string? description, int minPrice, int maxPrice, int[] categoryIds, int position, int skip);
    }
}
