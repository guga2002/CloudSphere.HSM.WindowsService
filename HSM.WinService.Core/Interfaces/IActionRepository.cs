using HSM.WinService.Core.Entitites;

namespace HSM.WinService.Core.Interfaces
{
    public interface IActionRepository:ICrudRespository<ActionCode>
    {
        Task<ActionCode> GetByCodeAsync(string id);
        Task<bool> DeleteAsync(string Code);
    }
}
