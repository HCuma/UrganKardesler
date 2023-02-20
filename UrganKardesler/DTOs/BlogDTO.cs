using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrganKardesler.DTOs
{
    public class BlogDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AuthorName { get; set; }
        public string ShortDescription { get; set; }
        public string ThumbnailName { get; set; }
        public string Category { get; set; }
        public string ThumbnailBase64Code { get; set; }
        public bool isActive { get; set; }
    }
}