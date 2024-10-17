using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreates
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Id = Guid.NewGuid();
            //Products = new List<ProductInfo>();
            Products = new List<ShoppingCartProduct>();
        }

        public Guid Id { get; set; }
        public string UserId{ get; set; }
        public User User { get; set; }
        //public ICollection<ProductInfo> Products { get; set; } = new List<ProductInfo>();
        public decimal TotalPrice { get; set; }

        public ICollection<ShoppingCartProduct> Products { get; set; }
        //adres bilgisi ve ödeme kontrolu yaptır 

    }
}
