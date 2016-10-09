using MiauCore.IO.Areas.Admin.SearchFilters;
using MiauCore.IO.Models;
using System.Collections.Generic;

namespace MiauCore.IO.Areas.Admin.Models
{
    public class InvestorViewModel
    {
        public IList<Investor> Investors { get; set; }
        public InvestorFilter Filter { get; set; }
    }
}
