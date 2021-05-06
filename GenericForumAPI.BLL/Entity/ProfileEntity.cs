using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericForum.Model.Entity
{
    public class ProfileEntity : BaseEntity
    {
        public string Biografia { get; set; }

        public virtual ClientEntity Client { get; set; }

       
        
        
    }
}
