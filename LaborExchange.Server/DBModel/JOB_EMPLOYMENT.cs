using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaborExchange.Server.DBModel
{
    public class JOB_EMPLOYMENT
    {
        [Key] public int ID { get; set; }
        public int JOB_ID { get; set; }

        [ForeignKey("JOB_ID")] public JOB_VACANCY JobVacancy { get; set; }

        public int EMPLOYEE_ID { get; set; }
        [ForeignKey("EMPLOYEE_ID")] public EMPLOYEE Employee { get; set; }

        public DateTime DATE_OF_EMPLOYMENT { get; set; }
    }
}