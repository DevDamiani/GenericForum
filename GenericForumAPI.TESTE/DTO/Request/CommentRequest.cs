using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GenericForum.Model.Request
{
    public class CommentRequest
    {
        [Required]
        public string TopicID { get; set; }
        [Required]
        public string CommentText { get; set; }


    }
}
