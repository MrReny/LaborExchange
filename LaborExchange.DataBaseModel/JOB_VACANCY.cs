using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaborExchange.DataBaseModel
{
    public class JOB_VACANCY
    {
        [Key]
        public int ID { get; set; }

        public string VACANCY_NAME { get; set; }

        public Nullable<int> PAYMENT { get; set; }

        public Nullable<int> EDUCATION { get; set; }

        public Nullable<int> EXPERIENCE { get; set; }


        public int EMPLOYER_ID { get; set; }
        [ForeignKey("EMPLOYER_ID")]
        public EMPLOYER Employer { get; set; }

        public short SATISFIED { get; set; }


    }
}
