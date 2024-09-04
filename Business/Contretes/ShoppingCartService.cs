using Business.Abstracts;
using Business.Request.ShoppingCartRequests;
using DataAccess.Abstracts;
using Entities.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contretes
{
    public class ShoppingCartService : IShoppingCartService
    {
        private IShoppingCartDal _ShoppingCartDal;

        public ShoppingCartService(IShoppingCartDal shoppingCartDal)
        {
            _ShoppingCartDal = shoppingCartDal;
        }

        public bool CreateShoppingCart(CreateShoppingCartRequest request)
        {
            ShoppingCart shoppingCartToAdd = new ShoppingCart
            {
                
                UserId = request.UserId,
                products = request.Products,
                TotalPrice = request.TotalPrice,
            };
            _ShoppingCartDal.Add(shoppingCartToAdd);
            return true;
        }

        public bool DeleteShoppingCart(DeleteShoppingCartRequest request)
        {
            ShoppingCart shoppingCartToDelete = _ShoppingCartDal.Get(x=> x.Id == request.Id);
           _ShoppingCartDal.Delete(shoppingCartToDelete);
            return true;
        }

        public ShoppingCart GetById(int id)
        {
            return _ShoppingCartDal.Get(x=>x.Id ==id);
        }

        public List<ShoppingCart> Getlist()
        {
            List<ShoppingCart> shoppingCarts = _ShoppingCartDal.GetList();
            return shoppingCarts;
        }

        public bool UpdateShoppingCart(UpdateShoppingCartRequest request)
        {
            ShoppingCart shoppingCartToUpdate = _ShoppingCartDal.Get(x => x.Id == request.Id);

            shoppingCartToUpdate.Id = request.Id;
            shoppingCartToUpdate.UserId = request.UserId;
            shoppingCartToUpdate.products = request.Products;
            shoppingCartToUpdate.TotalPrice = request.TotalPrice;
            _ShoppingCartDal.Update(shoppingCartToUpdate);
            return true;
        }
    }
}
