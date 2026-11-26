using entiti;

namespace service
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategories();
    }
}
