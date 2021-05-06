using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericForum.Model.Response
{
    public class ProfileResponse
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Biografia { get; set; }
        public IEnumerable<TopicBriefResponse> TopicBrief { get; set; }

    }
}
