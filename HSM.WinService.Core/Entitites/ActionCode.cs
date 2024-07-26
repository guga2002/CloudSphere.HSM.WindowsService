using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HSM.WinService.Core.Entitites
{
    [Table("ActionCodes")]
    public class ActionCode
    {
        [Key]
        public int  ActionId { get; set; }

        [Column("Code_Of_Action")]
        public string Code { get; set; }

        [Column("Action_In_English")]
        public string Action_En { get; set; }

        [Column("Action_in_Georgian")]
        public string Action_Ka { get; set; }

        [AllowedValues(true,false)]
        public bool IsEmergencySituation { get; set; }
    }
}
