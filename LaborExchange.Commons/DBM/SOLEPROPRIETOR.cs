using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;

namespace LaborExchange.Commons
{
    [Table("SOLE_PROPRIETORS")]
    public class SOLEPROPRIETOR:EMPLOYER
    {
        [Column("ITN")]
        public long Itn { get; set; }

        [Column("ITN")]
        public Passport Passport { get; set; }
    }
}