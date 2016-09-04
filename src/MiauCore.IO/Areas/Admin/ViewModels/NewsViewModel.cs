using MiauCore.IO.Domain.Models;
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
    }
}
