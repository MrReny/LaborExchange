using System;
using System.ComponentModel.DataAnnotations;
using LaborExchange.Commons;

namespace LaborExchange.Server.DBModel
{
    public class PASSPORT
    {
        [Key] public int ID { get; set; }

        public string FIRST_NAME { get; set; }

        public string SECOND_NAME { get; set; }

        public string FAMILY_NAME { get; set; }

        public DateTime PASSPORT_DATE_OF_BIRTH { get; set; }

        public int PASSPORT_SERIE { get; set; }

        public int PASSPORT_NUMBER { get; set; }

        public DateTime PASSPORT_DATE_OF_ISSUE { get; set; }

        public string PASSPORT_PLACE_OF_ISSUE { get; set; }

        public Passport ToTransportType()
        {
            return new Passport()
            {
                Id = ID,
                FirstName = FIRST_NAME,
                SecondName = SECOND_NAME,
                FamilyName = FAMILY_NAME,
                PassportSerie = PASSPORT_SERIE,
                PassportNumber = PASSPORT_NUMBER,
                PassportDateOfIssue = PASSPORT_DATE_OF_ISSUE,
                PassportPlaceOfIssue = PASSPORT_PLACE_OF_ISSUE
            };
        }

        public static PASSPORT FromTransportType(Passport p)
        {
            return new PASSPORT()
            {
                ID = p.Id,
                FIRST_NAME = p.FirstName,
                SECOND_NAME = p.SecondName,
                FAMILY_NAME = p.FamilyName,
                PASSPORT_SERIE = p.PassportSerie,
                PASSPORT_NUMBER = p.PassportNumber,
                PASSPORT_DATE_OF_ISSUE = p.PassportDateOfIssue,
                PASSPORT_PLACE_OF_ISSUE = p.PassportPlaceOfIssue
            };
        }
    }
}