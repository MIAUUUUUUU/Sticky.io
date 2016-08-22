using MiauCore.IO.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MiauCore.IO.Contexts
{
    public class MiauCoreContext : IdentityDbContext
    {
        //public MiauCoreContext(DbContextOptions<MiauCoreContext> options) : base(options)
        //{
        //}

        public static DbSet<BaseUser> Users { get; set; }
    }
}
