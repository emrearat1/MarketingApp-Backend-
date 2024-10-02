using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreates
{
    public class ShoppingCartProduct
    {
        public Guid ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
