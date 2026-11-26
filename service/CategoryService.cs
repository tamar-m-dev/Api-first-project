using entiti;
using repository;

namespace service
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepositpry CategoryRepositpry;
        public CategoryService(ICategoryRepositpry CategoryRepositpry)
        {
            this.CategoryRepositpry = CategoryRepositpry;
        }
        public async Task<List<Category>> GetCategories()
        {
            return await CategoryRepositpry.GetCategories();
        }
    }
}
