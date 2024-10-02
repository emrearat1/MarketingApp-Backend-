using Business.Abstracts;
using Business.Request.ShoppingCartRequests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        [HttpGet("/GetShoppingCartById")]
        public IActionResult GetShoppingCartById(Guid id) 
        {
            return Ok(_shoppingCartService.GetById(id));
        }
        [HttpPut("/UpdataShoppingCart")]
        public IActionResult UpdataShoppingCart(UpdateShoppingCartRequest request) 
        {
         return Ok(_shoppingCartService.UpdateShoppingCart(request));
        }

        //[HttpGet("/GetShoppingCarts")]
        //public IActionResult GetShoppingCarts() 
        //{
        //    return Ok(_shoppingCartService.Getlist());
        //}
        [HttpGet("/GetShoppingCarts")]
        public IActionResult GetShoppingCarts()
        {
            // Fetch the list of shopping carts from the service
            var shoppingCarts = _shoppingCartService.Getlist();

            // Set up JSON settings to handle circular references
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            // Serialize the list of shopping carts to JSON
            var jsonResult = JsonConvert.SerializeObject(shoppingCarts, settings);

            // Return the JSON result
            return Ok(jsonResult);
        }
    

    [HttpPost("/AddProductToCart")]
        public IActionResult AddProductToCart(Guid cartid, Guid productId)
        {
            return Ok(_shoppingCartService.AddProductToCart(cartid, productId));

        }
    }
}
