using System.ComponentModel.DataAnnotations;

namespace UrganKardesler.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string password { get; set; }

        public bool isPersistent { get; set; }
    }
}