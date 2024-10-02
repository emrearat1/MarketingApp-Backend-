using Business.Request.CommentRequests;
using Business.Request.UserRequests;
using Core;
using Entities.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICommentService
    {
        Comment GetById(Guid id);
        List<Comment> Getlist();
        bool CreateComment(CreateCommentRequest request);
        bool UpdateComment(UpdateCommentRequest request);
        bool DeleteComment(DeleteCommentRequest request);
        List<Comment> GetComments(QueryObject query);
    }
}
