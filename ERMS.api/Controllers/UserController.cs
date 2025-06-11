using ERMS.core.Models;
using ERMS.core.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERMS.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IProductService _productsService;
        public UserController(IProductService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("get-users")]
        public async Task<ActionResult<List<ProductModel>>> GetUsers()
        {
            try
            {
                //var users = await _userService.GetUsers();
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving users.");
            }
        }
    }
}
