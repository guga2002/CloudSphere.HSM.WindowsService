using HSM.WinService.Core.Entitites;

namespace HSM.WinService.Applications.Interfaces
{
    public interface IActionService
    {
        Task<ActionCode> GetByCodeAsync(string id);
        Task<bool> DeleteAsync(string Code);
        Task<bool> CreateAsync(ActionCode entity);
        Task<bool> UpdateAsync(ActionCode entity);
        Task<IEnumerable<ActionCode>> GetAllAsync();
    }
}
