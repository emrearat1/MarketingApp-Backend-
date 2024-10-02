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
    public class ProductDal : IProductDal
    {
        private readonly MarketAppContext _context;

        public ProductDal(MarketAppContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product? Get(Expression<Func<Product, bool>> expression)
        {
            return _context.Products.FirstOrDefault(expression);
        }

        public List<Product> GetList(Expression<Func<Product, bool>> expression = null)
        {
            return _context.Products.Include(u => u.Comments).ToList();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public List<Product> GetById(Guid id)
        {

            return _context.Products.Where(x => x.Id == id).ToList();

        }
    }
}
