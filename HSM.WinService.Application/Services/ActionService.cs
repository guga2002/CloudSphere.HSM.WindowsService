using HSM.WinService.Applications.Interfaces;
using HSM.WinService.Core.Entitites;
using HSM.WinService.Core.Interfaces;

namespace HSM.WinService.Applications.Services
{
    public class ActionService : IActionService
    {
        private readonly IActionRepository rep;

        public ActionService(IActionRepository rep)
        {
            this.rep = rep;
        }
        public Task<bool> CreateAsync(ActionCode entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            return rep.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(string Code)
        {
            return await rep.DeleteAsync(Code);
        }

        public Task<IEnumerable<ActionCode>> GetAllAsync()
        {
            return rep.GetAllAsync();
        }

        public Task<ActionCode> GetByCodeAsync(string id)
        {
            return rep.GetByCodeAsync(id);
        }

        public Task<bool> UpdateAsync(ActionCode entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            return rep.UpdateAsync(entity);
        }
    }
}
