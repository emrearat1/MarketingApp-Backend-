using Business.Abstracts;
using Business.Contretes;
using Business.Request.CommentRequests;
using Business.Request.UserRequests;
using Core;
using Entities.Concreates;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;

        }

        [HttpPost("/CreateComment")]
        public IActionResult CreateComment(CreateCommentRequest request)
        {
            return Ok(_commentService.CreateComment(request));
        }

        [HttpDelete("/DeleteCommentById")]
        public IActionResult DeleteComment(DeleteCommentRequest request)
        {
            return Ok(_commentService.DeleteComment(request));
        }

        [HttpGet("/GetCommentById")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_commentService.GetById(id));
        }

        [HttpPut("/UpdateComment")]
        public IActionResult UpdateComment(UpdateCommentRequest request)
        {
            return Ok(_commentService.UpdateComment(request));
        }


        [HttpGet("/GetComments")]
        public IActionResult GetAllComments()
        {
            List<Comment> comments = _commentService.Getlist();
            return Ok(comments);
        }

        //    [HttpGet("GetUsers")]
        //    public IActionResult GetUsers([FromQuery] QueryObject query)
        //    {
        //        // Check if the search keyword is provided
        //        var users = string.IsNullOrEmpty(query.SearchKeyword)
        //            ? _commentService.Getlist() // If no keyword is provided, retrieve all users
        //            : _commentService.GetComments(query); // If keyword is provided, filter users

        //        return Ok(users);
        //    }
        //}



    }
}

