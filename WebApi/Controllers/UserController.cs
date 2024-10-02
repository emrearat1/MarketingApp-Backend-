using Business.Abstracts;
using Business.Request.UserRequests;
using Core;
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
        public IActionResult GetById(Guid id)
        {
            return Ok(_userService.GetById(id));
        }

        [HttpPut("/UpdateUser")]
        public IActionResult UpdateUser(UpdateUserRequest request)
        {
            return Ok(_userService.UpdateUser(request));
        }

        // TODO AddPagination
        //[HttpGet("/GetUsers")]
        //public IActionResult GetAllUsers()
        //{
        //    List<User> users = _userService.Getlist();
        //    return Ok(users);
        //}

        [HttpGet("GetUsers")]
        public IActionResult GetUsers([FromQuery] QueryObject query)
        {
            // Check if the search keyword is provided
            var users = string.IsNullOrEmpty(query.SearchKeyword)
                ? _userService.Getlist() // If no keyword is provided, retrieve all users
                : _userService.GetUsers(query); // If keyword is provided, filter users

            return Ok(users);
        }
    }
}
