using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaborExchange.Commons
{
    [Table("PASSPORT")]
    public class PASSPORT
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("FIRST_NAME")]
        public string FirstName { get; set; }

        [Column("SECOND_NAME")]
        public string SecondName { get; set; }

        [Column("FAMILY_NAME")]
        public string FamilyName { get; set; }

        [Column("PASSPORT_SERIE")]
        public int PassportSerie { get; set; }

        [Column("PASSPORT_NUMBER")]
        public int PassportNumber { get; set; }

        [Column("PASSPORT_DATE_OF_ISSUE")]
        public DateTime PassportDateOfIssue { get; set; }

        [Column("PASSPORT_PLACE_OF_ISSUE")]
        public string PassportPlaceOfIssue { get; set; }
    }
}