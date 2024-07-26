using HSM.WinService.Core.Data;
using HSM.WinService.Core.Entitites;
using HSM.WinService.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HSM.WinService.Infrastructure.Repository
{
    public class ContactRepository : AbstractRepository<ContactInfo>, IContactInfoRepository
    {
        public ContactRepository(HsmDbContext HsmDbContext) : base(HsmDbContext)
        {
        }

        public async Task<bool> CreateAsync(ContactInfo entity)
        {
            if (await DbSet.AnyAsync(io => io.Email == entity.Email && io.PhoneNumber == entity.PhoneNumber))
            {
                return false;
            }
            await DbSet.AddAsync(entity);
            return await HsmDbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ContactInfo>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllEmails()
        {
            return await DbSet.Select(io => io.Email).ToListAsync();
        }

        public async Task<IEnumerable<string>> GetAllPhones()
        {
            return await DbSet.Select(io => io.PhoneNumber).ToListAsync();
        }

        public async Task<ContactInfo> GetByEmail(string Email)
        {
            return await DbSet.Where(io => io.Email==Email)
                .FirstOrDefaultAsync()
                ??throw new ArgumentNullException("Such  email no exist in db");
        }

        public async Task<ContactInfo> GetByPhone(string Phone)
        {
            return await DbSet.Where(io => io.PhoneNumber == Phone)
                .FirstOrDefaultAsync()
                ?? throw new ArgumentNullException("Such  Phone no exist in db");
        }

        public async  Task<bool> UpdateAsync(ContactInfo entity)
        {
           var res= await DbSet.FirstOrDefaultAsync(io=>io.ContactInfoId==entity.ContactInfoId);
            if(res is not null)
            {
                res.Position=entity.Position;
                res.PhoneNumber=entity.PhoneNumber;
                res.Surname=entity.Surname;
                res.Name=entity.Name;
                res.Email=entity.Email;
                return await HsmDbContext.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
