using entiti;
using Microsoft.AspNetCore.Mvc;
using service;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            List<Category> categories = await categoryService.GetCategories();
            if (categories != null)
            {
                return Ok(categories);
            }
            return NotFound();
        }
    }
}
