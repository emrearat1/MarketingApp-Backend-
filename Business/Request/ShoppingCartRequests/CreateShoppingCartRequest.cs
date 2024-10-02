using Entities.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Request.ShoppingCartRequests
{
    public class CreateShoppingCartRequest
    {
        
        public Guid UserId { get; set; }
        public string Products { get; set; }
        public int TotalPrice { get; set; }
    }
}
