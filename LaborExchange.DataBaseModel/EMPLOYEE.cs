using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaborExchange.DataBaseModel
{
    [Table("EMPLOYEES")]
    public class EMPLOYEE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        public int USER_ID { get; set; }

        [ForeignKey("USER_ID")]
        public USER USER { get; set; }

        public Nullable<int> EDUCATION { get; set; }
        public Nullable<int> EXPERIENCE { get; set; }

        public long ITN { get; set; }

        public int PASSPORT_ID { get; set; }
        [ForeignKey("PASSPORT_ID")]
        public PASSPORT PASSPORT { get; set; }
    }
}
