using Business.Request.ShoppingCartRequests;
using Entities.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IShoppingCartService
    {
        ShoppingCart GetById(Guid id);
        ShoppingCart GetByUserId(string userId);
        List<ShoppingCart> Getlist();
        bool CreateShoppingCart(string Id);
        bool UpdateShoppingCart(UpdateShoppingCartRequest request);
        bool DeleteShoppingCart(DeleteShoppingCartRequest request);
        bool AddProductToCart(Guid cartid, Guid productId);
        bool DeleteProductFromCart(Guid cartid, Guid productId);
    }
}
