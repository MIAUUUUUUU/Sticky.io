using MiauCore.IO.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace MiauCore.IO.Contexts
{
    public class MiauCoreContext : DbContext
    {
        public MiauCoreContext(DbContextOptions<MiauCoreContext> options) : base(options)
        {

        }

        public static DbSet<BaseUser> Users { get; set; }
    }
}
