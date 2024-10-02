using Entities.Concreates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Request.CommentRequests
{
    public class UpdateCommentRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        
    }
}
