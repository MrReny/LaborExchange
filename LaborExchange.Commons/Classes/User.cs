using MessagePack;

namespace LaborExchange.Commons
{
    [MessagePackObject]
    public class User
    {
        [IgnoreMember]
        public int UserId { get; set; }

        [Key(0)]
        public string Login { get; set; }

        [IgnoreMember]
        public string Password { get; set; }

        [Key(1)]
        public string Email { get; set; }

        [Key(2)]
        public UserType UserType { get; set; }
    }
}