using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;

namespace LaborExchange.Commons
{

    [MessagePackObject]
    public class Employee
    {
        [Key(0)]
        public int? Id { get; set; }

        [IgnoreMember]
        public int? UserId { get; set; }

        [Key(1)]
        public string FirstName => Passport.FamilyName;

        [Key(2)]
        public string SecondName { get; set; }

        [Key(3)]
        public string FamilyName { get; set; }

        [Key(4)]
        public Education? Education { get; set; }

        [Key(5)]
        public int? Experience { get; set; }

        [Key(6)]
        public long Itn { get; set; }

        [Key(7)]
        public Passport Passport { get; set; }
    }
}