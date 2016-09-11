using MiauCore.IO.Domain.Models;
using MiauCore.IO.Models;
using MiauCore.IO.Models.ManyToMany;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MiauCore.IO.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<InvestorReward>()
                .HasKey(t => new { t.InvestorId, t.RewardId });

            builder.Entity<InvestorReward>()
                .HasOne(pt => pt.Investor)
                .WithMany(i => i.InvestorReward)
                .HasForeignKey(pt => pt.InvestorId);

            builder.Entity<InvestorReward>()
                .HasOne(pt => pt.Reward)
                .WithMany(i => i.InvestorRewards)
                .HasForeignKey(pt => pt.RewardId);



            builder.Entity<ClientReward>()
                .HasKey(t => new { t.ClientId, t.RewardId });

            builder.Entity<ClientReward>()
                .HasOne(pt => pt.Client)
                .WithMany(i => i.ClientRewards)
                .HasForeignKey(pt => pt.ClientId);

            builder.Entity<ClientReward>()
                .HasOne(pt => pt.Reward)
                .WithMany(i => i.ClientRewards)
                .HasForeignKey(pt => pt.RewardId);

            base.OnModelCreating(builder);
        } 
        
        public DbSet<News> News { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Investor> Investors { get; set; }
        public DbSet<Reward> Rewards { get; set; }
    }
}
