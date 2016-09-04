using System;

namespace MiauCore.IO.Domain.Models
{
    public class News : IGenericEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
        public string BannerImage { get; set; }
        public DateTime WriteDate { get; set; }
        public DateTime LastRevisionDate { get; set; }
    }
}
