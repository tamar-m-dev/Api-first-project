using entiti;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository
{
    public interface IProductRepository
    {
        Task<(List<Product> products, int total)> GetProducts(string? description, int minPrice, int maxPrice, int[] categoryIds, int position, int skip);
    }
}
