using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreates
{
    public class Product
    {
        public Product()
        {
            Id = Guid.NewGuid();
            ShoppingCarts = new List<ShoppingCartProduct>();
        }

        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string MarketerId { get; set; }
        public string MarketerName { get; set; }
        public ICollection<ShoppingCartProduct> ShoppingCarts { get; set; }
        public ICollection<Comment> Comments { get; } = new List<Comment>();

    }

}
