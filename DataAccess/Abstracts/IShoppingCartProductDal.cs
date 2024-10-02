using Entities.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IShoppingCartProductDal
    {
        ShoppingCartProduct? Get(Expression<Func<ShoppingCartProduct, bool>> expression);
        //List<ShoppingCartProduct> GetList(Expression<Func<ShoppingCartProduct, bool>> expression = null);
        void Add(ShoppingCartProduct shoppingCartProduct);
        //void Update(ShoppingCartProduct shoppingCartProduct);
        void Delete(ShoppingCartProduct shoppingCartProduct);
    }
}
