using Business.Request.ProductRequests;
using Entities.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IProductService
    {
        Product GetById(Guid id);
        List<Product> Getlist();
        bool CreateProduct(CreateProductRequest request);
        bool UpdateProduct(UpdateProductRequest request);
        bool DeleteProduct(DeleteProductRequest request);
    }
}
