using HSM.WinService.Applications.Interfaces;
using HSM.WinService.Core.Entitites;
using HSM.WinService.Core.Interfaces;
using HSM.WinService.Infrastructure.Repository;

namespace HSM.WinService.Applications.Services
{
    public class ContactServices : IContactServices
    {
        private readonly IContactInfoRepository contactInfoRepository;
        private readonly SmtpService smtpService;
        public ContactServices(IContactInfoRepository contactInfoRepository, SmtpService smtpService)
        {
            this.contactInfoRepository = contactInfoRepository;
            this.smtpService = smtpService;
        }

        public async Task<bool> CreateAsync(ContactInfo entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            return await contactInfoRepository.CreateAsync(entity);
        }

        public async Task<IEnumerable<ContactInfo>> GetAllAsync()
        {
            return await contactInfoRepository.GetAllAsync();
        }

        public async Task<bool> SendMessageAlertWithEmail(string message)
        {
            var res = await contactInfoRepository.GetAllEmails();
            foreach (var email in res)
            {
                smtpService.SendMessage(email, $"Alert message set:{DateTime.Now.ToShortDateString()}", message);
            }
            return true;
        }

        public async Task<bool> UpdateAsync(ContactInfo entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));
            return await contactInfoRepository.UpdateAsync(entity);
        }
    }
}
