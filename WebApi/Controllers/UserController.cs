using Business.Abstracts;
using Business.Request.UserRequests;
using Entities.Concreates;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        //[HttpGet]
        //public User GetById(int id)
        //{
        //    return _userService.GetById(id);
        //}
        [HttpPost("/CreateUser")]
        public IActionResult CreateUSer(CreateUserRequest request)
        {
            return Ok(_userService.CreateUser(request));
        }

        [HttpDelete("/DeleteUserById")]
        public IActionResult DeleteUSer(DeleteUserRequest request) 
        {
            return Ok(_userService.DeleteUser(request));
        }

        [HttpGet("/GetUserById")]
        public IActionResult GetById(int id)
        {
            return Ok(_userService.GetById(id));
        }

        [HttpPut("/UpdateUser")]
        public IActionResult UpdateUser(UpdateUserRequest request) 
        { 
            return Ok(_userService.UpdateUser(request));
        }

        // TODO AddPagination
        [HttpGet("/GetUsers")]
        public IActionResult GetAllUsers()
        {
            List<User> users = _userService.Getlist();
            return Ok(users);
        }
    }
}
