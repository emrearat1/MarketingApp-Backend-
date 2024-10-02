using Entities.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface ICommentDal
    {
        Comment? Get(Expression<Func<Comment, bool>> expression);
        List<Comment> GetList(Expression<Func<Comment, bool>> expression = null);
        void Add(Comment comment);
        void Update(Comment comment);
        void Delete(Comment comment);
    }
}
