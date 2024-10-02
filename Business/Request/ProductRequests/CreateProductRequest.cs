using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Request.ProductRequests
{
    public class CreateProductRequest
    {
        
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string MarketerId { get; set; }
        
    }
}
