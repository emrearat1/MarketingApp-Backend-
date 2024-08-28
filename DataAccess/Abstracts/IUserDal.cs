using Entities.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IUserDal
    {
        User? Get(Expression<Func<User, bool>> expression);
        List<User> GetList(Expression<Func<User, bool>> expression = null);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
