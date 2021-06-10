using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LaborExchange.Commons;

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
        public virtual PASSPORT PASSPORT { get; set; }

        public Employee ToTransportType()
        {
            return new Employee()
            {
                Id = ID,
                UserId = USER_ID,
                Education = (Education?)EDUCATION,
                Experience = EXPERIENCE,
                Itn = ITN,
                Passport = PASSPORT?.ToTransportType()
            };
        }

        public static EMPLOYEE FromTransportType(Employee e)
        {
            return new EMPLOYEE()
            {
                EDUCATION = (int?) e.Education,
                EXPERIENCE = e.Experience,
                ID = e.Id,
                ITN = e.Itn,
                PASSPORT = PASSPORT.FromTransportType(e.Passport)
            };
        }
    }
}
