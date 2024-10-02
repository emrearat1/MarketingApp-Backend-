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
    public class ShoppingCartDal : IShoppingCartDal
    {
        private readonly MarketAppContext _context;

        public ShoppingCartDal(MarketAppContext context)
        {
            _context = context;
        }

        public void Add(ShoppingCart shoppingCart)
        {
            _context.ShoppingCarts.Add(shoppingCart);
            _context.SaveChanges();
        }

        public void Delete(ShoppingCart shoppingCart)
        {
            _context.ShoppingCarts.Remove(shoppingCart);
            _context.SaveChanges();
        }

        public ShoppingCart? Get(Expression<Func<ShoppingCart, bool>> expression)
        {
            return _context.ShoppingCarts.FirstOrDefault(expression);
        }

        public List<ShoppingCart> GetList(Expression<Func<ShoppingCart, bool>> expression = null)
        {
            return _context.ShoppingCarts.Include(u => u.User).Include(x => x.Products).ToList();
            //return _context.ShoppingCarts.Include(u => u.User).ToList();
        }

        public void Update(ShoppingCart shoppingCart)
        {
            _context.ShoppingCarts.Update(shoppingCart);
            _context.SaveChanges();
        }
        public List<ShoppingCart> GetById(Guid id)
        {

            return _context.ShoppingCarts.Where(x => x.Id == id).ToList();

        }

    
    }
}
