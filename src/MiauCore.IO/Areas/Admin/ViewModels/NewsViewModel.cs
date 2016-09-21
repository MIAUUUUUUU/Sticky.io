using MiauCore.IO.Domain.Models;
using MiauCore.IO.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiauCore.IO.Areas.Admin.ViewModels
{
    public class NewsViewModel
    {
        public NewsViewModel()
        {
            Errors = new List<string>();
        }
        public News News { get; set; }
        public IList<string> Errors { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public int ProductId { get; set; }
    }
}
