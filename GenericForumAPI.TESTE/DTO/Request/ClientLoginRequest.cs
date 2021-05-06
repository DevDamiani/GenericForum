using System.ComponentModel.DataAnnotations;

namespace GenericForum.Model.Request
{
    public class ClientLoginRequest
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
