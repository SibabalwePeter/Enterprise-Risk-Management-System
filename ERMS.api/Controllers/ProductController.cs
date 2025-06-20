using ERMS.DL.Models;
using ERMS.DL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERMS.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productsService;
        public ProductController(IProductService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("get-products")]
        public async Task<ActionResult<List<ProductModel>>> GetUsers()
        {
            try
            {
                var products = await _productsService.GetProducts();
                return Ok(products);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving users.");
            }
        }
    }
}
