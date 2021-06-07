using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaborExchange.DataBaseModel
{
    public class EMPLOYER
    {
        [Key]
        public int ID { get; set; }

        public int USER_ID { get; set; }

        [ForeignKey("USER_ID")]
        public USER User { get; set; }

        public Nullable<short> EMPLOYER_TYPE { get; set; }
        public string LEGAL_NAME { get; set; }
    }
}
