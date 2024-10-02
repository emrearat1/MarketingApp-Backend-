using Entities.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Request.UserRequests
{
    public class CreateUserRequest
    {
        
        public string UserName { get; set; } = "Username";
        public string Password { get; set; } = "Password";
        public int Wallet { get; set; } = 0;
        //public int? ShoppingCartId { get; set; } = null;


    }
}
