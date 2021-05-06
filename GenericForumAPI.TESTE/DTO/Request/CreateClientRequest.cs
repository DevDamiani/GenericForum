using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GenericForum.Model.Request
{
    public class CreateClientRequest
    {
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 8)]
        public string Password { get; set; }

    }
}
