using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;

namespace LaborExchange.Commons
{
    [Table("EMPLOYEES")]
    public class EMPLOYEE
    {
        [Column("ID")]
        public int? Id { get; set; }

        [Column("USER_ID")]
        [IgnoreMember]
        public int? UserId { get; set; }

        [Column("EDUCATION")]
        public Education? Education { get; set; }

        [Column("EXPERIENCE")]
        public int? Experience { get; set; }

        [Column("ITN")]
        public long Itn { get; set; }

        [Column("PASSPORT")]
        public PASSPORT Passport { get; set; }
    }
}