using MessagePack;

namespace LaborExchange.Commons
{
    [MessagePackObject]
    public class LegalEntity: Employer
    {
        [Key(3)]
        public long Psrn { get; set; }

        [Key(4)]
        public long Tin { get; set; }

        [Key(5)]
        public long Iec { get; set; }

        [Key(6)]
        public string LegalAddress { get; set; }
    }
}