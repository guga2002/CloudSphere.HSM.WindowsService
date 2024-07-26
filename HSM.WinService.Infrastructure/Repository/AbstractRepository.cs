using HSM.WinService.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace HSM.WinService.Infrastructure.Repository
{
    public abstract class AbstractRepository<T>where T : class
    {
        protected virtual HsmDbContext HsmDbContext { get; }
        protected virtual DbSet<T> DbSet { get; }

        protected AbstractRepository(HsmDbContext HsmDbContext)
        {
            this.HsmDbContext = HsmDbContext;
            DbSet= HsmDbContext.Set<T>();       
        }
    }
}
