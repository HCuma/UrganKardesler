using System;

namespace UrganKardesler.ViewModels
{
    public record BlogVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Article { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AuthorName { get; set; }
        public string ShortDescription { get; set; }
        public string ThumbnailName { get; set; }
        public string Category { get; set; }
        public bool isActive { get; set; }
    }
}