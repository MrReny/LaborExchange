using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;

namespace LaborExchange.Commons
{
    [Table("EMPLOYERS")]
    public class EMPLOYER
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("USER_ID")]
        public int UserId { get; set; }

        [Column("LEGAL_NAME")]
        public string LegalName { get; set; }

        [Column("EMPLOYER_TYPE")]
        public EmployerType Type { get; set; }
    }
}