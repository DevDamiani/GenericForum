using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GenericForum.Model.Request
{
    public class TopicRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Subtitle { get; set; }

    }
}
