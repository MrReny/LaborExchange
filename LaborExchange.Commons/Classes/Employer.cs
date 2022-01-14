using MessagePack;

namespace LaborExchange.Commons
{
    [MessagePackObject]
    public class Employer
    {
        [Key(0)]
        public int Id { get; set; }

        [IgnoreMember]
        public int UserId { get; set; }

        [Key(1)]
        public string LegalName { get; set; }

        [Key(2)]
        public EmployerType Type { get; set; }
    }
}