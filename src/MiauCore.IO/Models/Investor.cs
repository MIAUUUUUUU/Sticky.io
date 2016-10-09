using MiauCore.IO.Models.ManyToMany;
using System.Collections.Generic;

namespace MiauCore.IO.Models
{
    public class Investor : IGenericEntity
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string NERC { get; set; }
        public string Message { get; set; }
        public virtual ICollection<InvestorReward> InvestorReward { get; set; }
    }
}
