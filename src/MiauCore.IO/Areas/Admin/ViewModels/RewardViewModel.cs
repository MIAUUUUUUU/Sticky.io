using MiauCore.IO.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MiauCore.IO.Areas.Admin.ViewModels
{
    public class RewardViewModel
    {
        public Reward Reward { get; set; }
        public int ProductId { get; set; }
        public SelectList ProductList { get; set; }
    }
}
