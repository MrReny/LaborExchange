using System.ComponentModel.DataAnnotations;

namespace LaborExchange.DataBaseModel
{
    public class PASSPORT
    {
        [Key]
        public int ID { get; set; }
        public string FIRST_NAME { get; set; }
        public string SECOND_NAME { get; set; }
        public string FAMILY_NAME { get; set; }
        public int PASSPORT_SERIE { get; set; }
        public int PASSPORT_NUMBER { get; set; }
        public System.DateTime PASSPORT_DATE_OF_ISSUE { get; set; }
        public string PASSPORT_PLACE_OF_ISSUE { get; set; }


    }
}
