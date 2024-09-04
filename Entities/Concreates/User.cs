using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreates
{
    public class User
    {
        public User()
        {
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Wallet { get; set; }
        public List<ShoppingCart> ShoppingCarts { get; } = new List<ShoppingCart>();
        //public int? ShoppingCartId { get; set; }
        //public ShoppingCart? ShoppingCart { get; set; }


    }
}
