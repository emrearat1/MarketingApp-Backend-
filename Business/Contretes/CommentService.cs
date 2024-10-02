using Business.Abstracts;
using Business.Request.CommentRequests;
using Core;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;
using Entities.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contretes
{
    public class CommentService : ICommentService
    {
        private ICommentDal _commentDal;
        public CommentService(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public bool CreateComment(CreateCommentRequest request)
        {
            Comment commentToAdd = new Comment 
            {
                UserId = request.UserId,
                ProductId = request.ProductId,
                Title = request.Title,
                Body = request.Body,
            };
            _commentDal.Add(commentToAdd);
            return true;
        }
        
        
        public bool DeleteComment(DeleteCommentRequest request)
        {
            Comment commentToDelete = _commentDal.Get(f =>f.Id == request.Id);
            _commentDal.Delete(commentToDelete);
            return true;
        }

        public Comment GetById(Guid id)
        {
            Comment comment = _commentDal.Get(x=> x.Id == id);
            return comment;
        }

        public List<Comment> GetComments(QueryObject query)
        {
            throw new NotImplementedException();
        }

        public List<Comment> Getlist()
        {
            return _commentDal.GetList();
        }
        public List<T> GetList<T>(QueryObject query, List<T> items, Func<T, bool> searchPredicate)
        {
            if (!string.IsNullOrEmpty(query.SearchKeyword))
            {
                items = items.Where(searchPredicate).ToList();
            }
            return items;
        }

        public bool UpdateComment(UpdateCommentRequest request)
        {
            Comment commentToUpdate = _commentDal.Get(x => x.Id == request.Id);
            commentToUpdate.Title = request.Title;
            commentToUpdate.Body = request.Body;    
            _commentDal.Update(commentToUpdate);
            return true;
        }
    }
}
