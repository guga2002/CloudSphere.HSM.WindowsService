using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HSM.WinService.Core.Data
{
    public class HsmDbContextFactory : IDesignTimeDbContextFactory<HsmDbContext>
    {
        public HsmDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<HsmDbContext>();
            optionsBuilder.UseSqlite("Data Source=C:\\Databases\\HSMDatabase.db");

            return new HsmDbContext(optionsBuilder.Options);
        }
    }
}
