using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Context;
using Entities.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class ShoppingCartProductDal : IShoppingCartProductDal
    {
        private readonly MarketAppContext _context;

        public ShoppingCartProductDal(MarketAppContext context)
        {
            _context = context;
        }

        public void Add(ShoppingCartProduct shoppingCartProduct)
        {
            _context.ShoppingCartProducts.Add(shoppingCartProduct);
            _context.SaveChanges();
        }

        public void Delete(ShoppingCartProduct shoppingCartProduct)
        {
            _context.ShoppingCartProducts.Remove(shoppingCartProduct);
            _context.SaveChanges();
        }

        public ShoppingCartProduct? Get(Expression<Func<ShoppingCartProduct, bool>> expression)
        {
            return _context.ShoppingCartProducts.FirstOrDefault(expression);
        }

        //public List<ShoppingCartProduct> GetList(Expression<Func<ShoppingCartProduct, bool>> expression = null)
        //{
        //    return _context.ShoppingCartProducts.Where(x => x.Id == id).ToList();
        //}

        //public void Update(ShoppingCartProduct shoppingCartProduct)
        //{
        //    _context.ShoppingCarts.Update(shoppingCart);
        //    _context.SaveChanges();
        //}
    }
}
