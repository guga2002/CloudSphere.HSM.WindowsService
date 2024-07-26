using HSM.WinService.Core.Entitites;

namespace HSM.WinService.Applications.Interfaces
{
    public interface IContactServices
    {
        Task<bool> CreateAsync(ContactInfo entity);
        Task<bool> UpdateAsync(ContactInfo entity);
        Task<IEnumerable<ContactInfo>> GetAllAsync();
        Task<bool> SendMessageAlertWithEmail(string message);
    }
}
