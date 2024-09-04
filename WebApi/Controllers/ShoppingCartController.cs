using Business.Abstracts;
using Business.Request.ShoppingCartRequests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpPost("/CreateShoppingCart")]
        public IActionResult CreaatShoppingCart(CreateShoppingCartRequest request)
        {
            return Ok(_shoppingCartService.CreateShoppingCart(request));
            
        }

    }
}
