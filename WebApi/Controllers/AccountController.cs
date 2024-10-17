using Business.Abstracts;
using Business.Contretes;
using Business.Request.ShoppingCartRequests;
using Business.Request.UserRequests;
using Core;
using Entities.Concreates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<User> _signInManager;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IProductService _productService;
        public AccountController(UserManager<User> userManager,ITokenService tokenService,SignInManager<User> signInManager,IShoppingCartService shoppingCartService,IProductService productService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _shoppingCartService = shoppingCartService;
            _productService = productService;
        }



        [HttpPost("AddProductToMyCart")]
        [Authorize]
        public async Task<IActionResult> AddProductToMyCart(Guid productId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId == null)
                {
                    return Unauthorized("User is not authorized.");
                }

                var shoppingCart = _shoppingCartService.GetByUserId(userId);

                if (shoppingCart == null)
                {
                    return NotFound("Shopping cart not found.");
                }
                var result = _shoppingCartService.AddProductToCart(shoppingCart.Id, productId);

                if (!result)
                {
                    return StatusCode(500, "Failed to add product to the cart.");
                }

                return Ok("Product added to your shopping cart successfully.");
            }

            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred: {ex.Message}");
            }


        }

        [HttpPost("DeleteProductFromMyCart")]
        [Authorize]
        public async Task<IActionResult> DeleteProductFromMyCart(Guid productId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId == null)
                {
                    return Unauthorized("User is not authorized.");
                }

                var shoppingCartToFind = _shoppingCartService.GetByUserId(userId);

                if (shoppingCartToFind == null)
                {
                    return NotFound("Shopping cart not found.");
                }

                var productToFind = _productService.GetById(productId);

                if (productToFind == null)
                {
                    return NotFound("Product cart not found.");
                }
                return Ok(_shoppingCartService.DeleteProductFromCart(shoppingCartToFind.Id,productToFind.Id));

            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }







        [HttpGet("GetMyCart")]
        [Authorize]
        public async Task<IActionResult> GetMyCart()
        {
            try {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                
                if(userId == null)
                {
                    return Unauthorized("User is not authorized.");
                }

                var shoppingCartToFind = _shoppingCartService.GetByUserId(userId);

                if (shoppingCartToFind == null)
                {
                    return NotFound("Shopping cart not found.");
                }

                return Ok(shoppingCartToFind);

            } 
            catch (Exception ex) 
            {

                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x=>x.UserName == loginRequest.Username);
            if (user == null) return Unauthorized("Invalid Username");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginRequest.Passworld,false);
            if(!result.Succeeded) return Unauthorized("Invalid Username or Passworld");
            return Ok(
            
                new NewUser
                {
                    Username = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)

                }
                
                
                
            );
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var user = new User
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email,
                    

                };

                var createdUser = await _userManager.CreateAsync(user,registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(user, "User");
                    if (roleResult.Succeeded)
                    {

                      
                        // Call service to create the shopping cart
                        var cartCreated = _shoppingCartService.CreateShoppingCart(user.Id);
                        if (!cartCreated)
                        {
                            return StatusCode(500, "Failed to create shopping cart");
                        }



                        return Ok(


                            new NewUser
                            {
                                Username =user.UserName,
                                Email = user.Email,
                                Token = _tokenService.CreateToken(user)
                            }

                            );
                    }
                    else 
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                } 

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
 
        }
    }
    



    }


