using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericForum.Model.Response
{
    public class CommentResponse
    {


        public string CommentText { get; set; }
        public DateTime Date { get; set; }
        public ClientResponse Client { get; set; }

    }
}
