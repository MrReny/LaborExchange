using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaborExchange.Server.DBModel
{
    public class SOLE_PROPRITEOR
    {
        public int EMPLOYER_ID { get; set; }
        [ForeignKey("EMPLOYER_ID")]
        public virtual EMPLOYER Employer { get; set; }

        [Key]
        public long PSRNSP { get; set; }
        public long ITN { get; set; }

        public int PASSPORT_ID { get; set; }
        [ForeignKey("PASSPORT_ID")]
        public PASSPORT PASSPORT { get; set; }
    }
}
