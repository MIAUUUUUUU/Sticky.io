using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiauCore.IO.Models.ManyToMany
{
    public class ClientReward
    {
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int RewardId { get; set; }
        public Reward Reward { get; set; }
    }
}
