using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Context;
using Entities.Concreates;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class CommentDal : ICommentDal
    {
        private readonly MarketAppContext _context;

        public CommentDal(MarketAppContext context)
        {
            _context = context;
        }
        public void Add(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void Delete(Comment comment)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

        public Comment? Get(Expression<Func<Comment, bool>> expression)
        {
            return _context.Comments.FirstOrDefault(expression);
        }

        public List<Comment> GetList(Expression<Func<Comment, bool>> expression = null)
        {
            return _context.Comments.ToList();
        }

        public void Update(Comment comment)
        {
            _context.Comments.Update(comment);
            _context.SaveChanges();
        }

        public List<Comment> GetById(Guid id)
        {

            return _context.Comments.Where(x => x.Id == id).ToList();

        }
    }
}
