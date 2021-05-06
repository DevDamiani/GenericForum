using System;
using System.Collections.Generic;

namespace GenericForum.Model.Response
{
    public class TopicResponse
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public DateTime Date { get; set; }
        public ClientResponse Client { get; set; }
        public IList<CommentResponse> Comments { get; set; }

    }
}
