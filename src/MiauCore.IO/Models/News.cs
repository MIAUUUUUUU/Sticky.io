using MiauCore.IO.Domain.Models;
using MiauCore.IO.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiauCore.IO.Models
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
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public string PublishedBy { get; set; }
    }
}
