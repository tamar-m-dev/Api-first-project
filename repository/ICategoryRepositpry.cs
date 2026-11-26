using entiti;

namespace repository
{
    public interface ICategoryRepositpry
    {
        Task<List<Category>> GetCategories();
    }
}
