using Entities.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IShoppingCartDal
    {
        ShoppingCart? Get(Expression<Func<ShoppingCart, bool>> expression);
        List<ShoppingCart> GetList(Expression<Func<ShoppingCart, bool>> expression = null);
        void Add(ShoppingCart shoppingCart);
        void Update(ShoppingCart shoppingCart);
        void Delete(ShoppingCart shoppingCart);
    }
}
