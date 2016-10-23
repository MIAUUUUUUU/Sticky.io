using MiauCore.IO.Models.ManyToMany;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiauCore.IO.Models
{
    public class Reward : IGenericEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Prize { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public List<ClientReward> ClientRewards { get; set; }
        public List<InvestorReward> InvestorRewards { get; set; }
    }
}
