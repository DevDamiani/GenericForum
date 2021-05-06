using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericForum.Model.Response
{
    public class TopicBriefResponse
    {


        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public DateTime Date { get; set; }
        public ClientResponse Client { get; set; }


    }

}
