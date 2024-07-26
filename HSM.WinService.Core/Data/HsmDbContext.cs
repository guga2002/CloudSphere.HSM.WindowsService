using HSM.WinService.Core.Configuration;
using HSM.WinService.Core.Entitites;
using Microsoft.EntityFrameworkCore;

namespace HSM.WinService.Core.Data
{
    public class HsmDbContext:DbContext
    {

        public HsmDbContext(DbContextOptions<HsmDbContext>ops ):base(ops)
        {
                
        }

        public virtual DbSet<ActionCode> ActionCodes { get; set; }
        public virtual DbSet<ContactInfo> ContactInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SeedActionCodes());
        }
    }
}
