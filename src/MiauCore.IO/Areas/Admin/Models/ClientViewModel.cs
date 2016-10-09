using MiauCore.IO.Areas.Admin.SearchFilters;
using MiauCore.IO.Models;
using System.Collections.Generic;

namespace MiauCore.IO.Areas.Admin.Models
{
    public class ClientViewModel
    {
        public ClientFilter Filter { get; set; }
        public IList<Client> Clients { get; set; }
    }
}