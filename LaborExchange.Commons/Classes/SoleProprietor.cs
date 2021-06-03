using MessagePack;

namespace LaborExchange.Commons
{
    [MessagePackObject]
    public class SoleProprietor:Employer
    {
        [Key(3)]
        public long Itn { get; set; }
        [Key(4)]
        public Passport Passport { get; set; }
    }
}