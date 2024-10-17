using Business.Abstracts;
using Business.Request.ProductRequests;
using DataAccess.Abstracts;
using Entities.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contretes
{
    public class ProductService : IProductService
    {
        private IProductDal _productDal;

        public ProductService(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public bool CreateProduct(CreateProductRequest request)
        {
            Product productToAdd = new Product
            {
                MarketerId = request.MarketerId,
                ProductName = request.ProductName,
                MarketerName = "BURAYI DÜZELT",
                Price = request.Price,

            };
            _productDal.Add(productToAdd);
            return true;
        }

        public bool DeleteProduct(DeleteProductRequest request)
        {
            Product productToDelete = _productDal.Get(x=>x.Id == request.Id);
            _productDal.Delete(productToDelete);
            return true;
        }

        public Product GetById(Guid id)
        {
            
            return _productDal.Get(x => x.Id == id);
        }

        public List<Product> Getlist()
        {
            List<Product> products = _productDal.GetList();
            return products;
        }

        public bool UpdateProduct(UpdateProductRequest request)
        {
            Product productToUpdate = _productDal.Get(x=>x.Id == request.Id);
            productToUpdate.Price = request.Price;
            productToUpdate.ProductName = request.ProductName;
            productToUpdate.MarketerId = request.MarketerId;
            
            _productDal.Update(productToUpdate);
            return true;
        }
    }
}
