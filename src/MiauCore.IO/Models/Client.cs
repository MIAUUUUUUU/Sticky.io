using MiauCore.IO.Models.ManyToMany;
using System.Collections.Generic;

namespace MiauCore.IO.Models
{
    public class Client : IGenericEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string TaxId { get; set; }
        public string Rate { get; set; }
        public string MobilePhone { get; set; }
        public virtual ICollection<ClientReward> ClientRewards { get; set; }
    }
}
