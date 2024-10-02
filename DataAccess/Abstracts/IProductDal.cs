using Entities.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts
{
    public interface IProductDal
    {
        Product? Get(Expression<Func<Product, bool>> expression);
        List<Product> GetList(Expression<Func<Product, bool>> expression = null);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
    }
}
