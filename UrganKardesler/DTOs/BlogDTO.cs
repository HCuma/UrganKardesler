using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrganKardesler.DTOs
{
    public class BlogDTO
    {
        public int Id { get; set; }

        [MaxLength(60)]
        [MinLength(3)]
        [Required]
        public string Title { get; set; }

        [MinLength(70)]
        [Required]
        public string Article { get; set; }

        public DateTime CreatedDate { get; set; }
        public string AuthorName { get; set; }

        [MaxLength(250)]
        [MinLength(30)]
        [Required]
        public string ShortDescription { get; set; }


        public string ThumbnailName { get; set; }

        [MinLength(3)]
        [MaxLength(25)]
        [Required]
        public string Category { get; set; }

        public string ThumbnailBase64Code { get; set; }
        public bool isActive { get; set; }
    }
}