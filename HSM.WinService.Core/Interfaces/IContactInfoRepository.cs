using HSM.WinService.Core.Entitites;

namespace HSM.WinService.Core.Interfaces
{
    public interface IContactInfoRepository:ICrudRespository<ContactInfo>
    {
        Task<IEnumerable<string>> GetAllEmails();
        Task<IEnumerable<string>> GetAllPhones();
        Task<ContactInfo> GetByEmail(string Email);
        Task<ContactInfo> GetByPhone(string Phone);
    }
}
