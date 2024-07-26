using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HSM.WinService.Core.Entitites
{
    [Table("ContactInfos")]
    public class ContactInfo
    {
        [Key]
        public int ContactInfoId { get; set; }
        public string Position { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
