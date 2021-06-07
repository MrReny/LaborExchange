using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaborExchange.DataBaseModel
{


    public class JOB_OFFER
    {
        [Key]
        public int ID { get; set; }

        public int JOB_ID { get; set; }
        [ForeignKey("JOB_ID")]
        public JOB_VACANCY JobVacancy { get; set; }


        public int EMPLOYEE_ID { get; set; }
        [ForeignKey("EMPLOYEE_ID")]
        public EMPLOYEE Employee { get; set; }

        public System.DateTime DATE_OF_OFFER { get; set; }
        public Nullable<int> STATE { get; set; }
        public int INITIATOR_TYPE { get; set; }



    }
}
