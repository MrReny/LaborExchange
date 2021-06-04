using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;

namespace LaborExchange.Commons
{
    [Table("LEGAL_ENTITIES")]
    public class LEGALENTITY: Employer
    {
        [Column("PSRN")]
        public long Psrn { get; set; }

        [Column("TIN")]
        public long Tin { get; set; }

        [Column("IEC")]
        public long Iec { get; set; }

        [Column("LEGAL_ADDRESS")]
        public string LegalAddress { get; set; }
    }
}