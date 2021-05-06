using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GenericForum.Model.Entity
{
    public class ClientEntity : BaseEntity
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }


        public virtual IList<TopicEntity> Topics { get; set; }

        public virtual ProfileEntity Profile { get; set; }


       
    }
}
