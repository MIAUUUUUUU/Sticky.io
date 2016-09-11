using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiauCore.IO.Models.ManyToMany
{
    public class InvestorReward
    {
        public int InvestorId { get; set; }
        public Investor Investor { get; set; }

        public int RewardId { get; set; }
        public Reward Reward { get; set; }
    }
}
