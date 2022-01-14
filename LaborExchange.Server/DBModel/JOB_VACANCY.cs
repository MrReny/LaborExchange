using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LaborExchange.Commons;

namespace LaborExchange.Server.DBModel
{
    public class JOB_VACANCY
    {
        [Key] public int ID { get; set; }

        public string VACANCY_NAME { get; set; }

        public Nullable<int> PAYMENT { get; set; }

        public Nullable<int> EDUCATION { get; set; }

        [NotMapped] public Education Education => EDUCATION == null ? Education.NoEducation : (Education)EDUCATION;

        [NotMapped] public string EducationString => Education.GetEnumDescription();

        public Nullable<int> EXPERIENCE { get; set; }

        public int EMPLOYER_ID { get; set; }

        [ForeignKey("EMPLOYER_ID")] public EMPLOYER EMPLOYER { get; set; }

        public short SATISFIED { get; set; }

        public JOB_VACANCY()
        {
        }

        public JOB_VACANCY(EMPLOYER employer)
        {
            EMPLOYER = employer;
        }

        public Job ToTransportType()
        {
            return new Job()
            {
                Id = ID,
                Education = Education,
                Experience = EXPERIENCE ?? 0,
                Payment = PAYMENT,
                Employer = EMPLOYER.ToTransportType(),
                JobName = VACANCY_NAME
            };
        }

        public static JOB_VACANCY FromTransportType(Job e)
        {
            return new JOB_VACANCY()
            {
                ID = e.Id,
                EDUCATION = (int?)e.Education,
                EXPERIENCE = e.Experience,
                PAYMENT = e.Payment,
                EMPLOYER = EMPLOYER.FromTransportType(e.Employer),
                EMPLOYER_ID = e.Employer.Id
            };
        }
    }
}