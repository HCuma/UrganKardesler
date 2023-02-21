using System.ComponentModel.DataAnnotations;

namespace UrganKardesler.DTOs
{
    public class CorporateDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Article { get; set; }
    }
}