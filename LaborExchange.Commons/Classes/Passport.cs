using System;
using MessagePack;

namespace LaborExchange.Commons
{
    [MessagePackObject]
    public class Passport
    {
        [IgnoreMember]
        public int Id { get; set; }

        [Key(1)]
        public string FirstName { get; set; }

        [Key(2)]
        public string SecondName { get; set; }

        [Key(3)]
        public string FamilyName { get; set; }

        [Key(4)]
        public int PassportSerie { get; set; }

        [Key(5)]
        public int PassportNumber { get; set; }

        [Key(6)]
        public DateTime PassportDateOfIssue { get; set; }

        [Key(7)]
        public string PassportPlaceOfIssue { get; set; }
    }
}