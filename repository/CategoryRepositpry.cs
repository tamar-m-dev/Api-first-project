using entiti;
using Microsoft.EntityFrameworkCore;

namespace repository
{
    public class CategoryRepositpry : ICategoryRepositpry
    {
        my_shopContext _context;
        public CategoryRepositpry(my_shopContext _context)
        {
            this._context = _context;
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
