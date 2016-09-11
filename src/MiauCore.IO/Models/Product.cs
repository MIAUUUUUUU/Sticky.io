using System.Collections.Generic;

namespace MiauCore.IO.Models
{
    public class Product : IGenericEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Reward> Rewards { get; set; }
    }
}
