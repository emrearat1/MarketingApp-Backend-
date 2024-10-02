using Business.Abstracts;
using Business.Request.ProductRequests;
using Business.Request.UserRequests;
using Entities.Concreates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("/CreateProduct")]
        public IActionResult CreateProduct(CreateProductRequest request)
        {
            return Ok(_productService.CreateProduct(request));
        }

        
        [HttpGet("/GetProducts")]
        public IActionResult GetAllProducts()
        {
            List<Product> products = _productService.Getlist();
            return Ok(products);
        }

    }
}
