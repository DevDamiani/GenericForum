using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericForum.Model.Entity
{
    public class CommentEntity : BaseEntity
    {

        public string CommentText { get; set; }
        public DateTime CreationDate { get; set; }

        
        public int TopicId { get; set; }
        public virtual TopicEntity Topic { get; set; }


        public int ClientId { get; set; }
        public virtual ClientEntity Client { get; set; }

       
    }
}
