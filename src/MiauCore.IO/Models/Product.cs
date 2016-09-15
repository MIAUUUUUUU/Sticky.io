using System.Collections.Generic;

namespace MiauCore.IO.Models
{
    public class Product : IGenericEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public virtual ICollection<News> News { get; set; }
        public virtual ICollection<Reward> Rewards { get; set; }
    }
}
