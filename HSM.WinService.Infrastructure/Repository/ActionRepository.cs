using HSM.WinService.Core.Data;
using HSM.WinService.Core.Entitites;
using HSM.WinService.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HSM.WinService.Infrastructure.Repository
{
    public class ActionRepository : AbstractRepository<ActionCode>, IActionRepository
    {
        public ActionRepository(HsmDbContext HsmDbContext) : base(HsmDbContext)
        {
        }

        public async Task<bool> CreateAsync(ActionCode entity)
        {
            if (await DbSet.AnyAsync(io => io.Code == entity.Code && io.Action_En == entity.Action_En))
            {
                return false;
            }
            await DbSet.AddAsync(entity);
            return await HsmDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(string Code)
        {
           var res=await DbSet.FirstOrDefaultAsync(io => io.Code == Code);
            if (res is not null)
            {
                DbSet.Remove(res);
                return await HsmDbContext.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<IEnumerable<ActionCode>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<ActionCode> GetByCodeAsync(string Code)
        {
            var res = await DbSet.FirstOrDefaultAsync(io => io.Code == Code);
            if (res is not null)
            {
                return res;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(ActionCode entity)
        {
            var res = await DbSet.FirstOrDefaultAsync(io => io.ActionId == entity.ActionId);
            if (res is not null)
            {
                res.Code = entity.Code;
                res.Action_En = entity.Action_En;
                res.Action_Ka = entity.Action_Ka;
                return await HsmDbContext.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
