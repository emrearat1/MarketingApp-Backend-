using Entities.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Request.CommentRequests
{
    public class CreateCommentRequest
    {   
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
       
        
    }
}
