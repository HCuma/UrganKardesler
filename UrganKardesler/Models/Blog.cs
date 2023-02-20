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
        public string Title { get; set; }

        public string Article { get; set; }

        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(IdentityUser))]
        public string AuthorId { get; set; }

        [MaxLength(250)]
        public string ShortDescription { get; set; }

        public string ThumbnailName { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [MaxLength(25)]
        public string Category { get; set; }

        public bool isActive { get; set; }
    }
}