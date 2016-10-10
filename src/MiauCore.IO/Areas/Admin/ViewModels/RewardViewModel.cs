using MiauCore.IO.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MiauCore.IO.Areas.Admin.ViewModels
{
    public class RewardViewModel
    {
        public Reward Reward { get; set; }
        public int ProductId { get; set; }
        public IList<Product> Products { get; set; }
    }
}
