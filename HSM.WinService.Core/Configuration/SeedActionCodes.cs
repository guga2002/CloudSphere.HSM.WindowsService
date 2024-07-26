using HSM.WinService.Core.Entitites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HSM.WinService.Core.Configuration
{
    public class SeedActionCodes : IEntityTypeConfiguration<ActionCode>
    {
        public void Configure(EntityTypeBuilder<ActionCode> builder)
        {
            builder.HasData(
                new ActionCode { ActionId = 1, Code = "101", Action_En = "Room one Have Error, Check Air Condition", Action_Ka = "პირველ ოთახს აქვს ხარვეზი, შეამოწმე თერმოსტატი!" }
                );
        }
    }
}
