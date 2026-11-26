using entiti;
using service;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<(List<Product> products, int total)>> Get([FromQuery] string? description,int minPrice, int maxPrice,int[] categoryIds , int position = 0, int skip = 8)
        {
            var (products, total) = await productService.GetProducts(description,minPrice,maxPrice,categoryIds,position,skip);
            if (products != null)
            {
                return Ok((products, total));
            }
            return NotFound();
        }
    }
}
