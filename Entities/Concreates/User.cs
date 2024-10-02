using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concreates
{
    public class User /*: IdentityUser<Guid>*/
    {
        public User()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        //public string Password { get; set; }
        public int Wallet { get; set; }
        //public ShoppingCart ShoppingCart { get; set; }
        public ICollection<ShoppingCart> ShoppingCarts { get; } = new List<ShoppingCart>();
        //public int? ShoppingCartId { get; set; }
        //public ShoppingCart? ShoppingCart { get; set; }
        public ICollection<Comment> Comments { get; } = new List<Comment>();

    }

   
