using MiauCore.IO.Models.ManyToMany;
using System.Collections.Generic;

namespace MiauCore.IO.Models
{
    public class Investor : IGenericEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string TaxId { get; set; }
        public int Rate { get; set; }
        public virtual ICollection<InvestorReward> InvestorReward { get; set; }
    }
}
