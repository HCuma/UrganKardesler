using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrganKardesler.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [MaxLength(60)]
        [MinLength(3)]
        public string Title { get; set; }

        [MinLength(100)]
        public string Article { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(IdentityUser))]
        public string AuthorId { get; set; }

        [MaxLength(250)]
        [MinLength(30)]
        public string ShortDescription { get; set; }

        public string ThumbnailName { get; set; }
        public IdentityUser IdentityUser { get; set; }

        public string Category { get; set; }
    }
}