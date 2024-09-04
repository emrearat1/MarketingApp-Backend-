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
        ShoppingCart GetById(int id);
        List<ShoppingCart> Getlist();
        bool CreateShoppingCart(CreateShoppingCartRequest request);
        bool UpdateShoppingCart(UpdateShoppingCartRequest request);
        bool DeleteShoppingCart(DeleteShoppingCartRequest request);
    }
}
