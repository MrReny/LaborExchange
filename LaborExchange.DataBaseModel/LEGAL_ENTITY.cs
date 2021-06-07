using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaborExchange.DataBaseModel
{
    public class LEGAL_ENTITY
    {

        public int EMPLOYER_ID { get; set; }
        [ForeignKey("EMPLOYER_ID")]
        public EMPLOYER Employer { get; set; }

        [Key]
        public long PSRN { get; set; }
        public long TIN { get; set; }
        public long IEC { get; set; }
        public string LEGAL_ADDRESS { get; set; }


    }
}
