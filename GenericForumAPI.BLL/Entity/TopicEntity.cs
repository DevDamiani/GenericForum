using System;
using System.Collections.Generic;

namespace GenericForum.Model.Entity
{
    public class TopicEntity : BaseEntity
    {

        public string Title { get; set; }
        public string Subtitle { get; set; }
        public DateTime CreationDate { get; set; }


        public int ClientID { get; set; }
        public virtual ClientEntity Client { get; set; }

        public virtual IList<CommentEntity> Comments { get; set; }



    }
}
