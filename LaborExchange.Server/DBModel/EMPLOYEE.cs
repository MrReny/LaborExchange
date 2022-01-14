using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LaborExchange.Commons;

namespace LaborExchange.Server.DBModel
{
    [Table("EMPLOYEES")]
    public class EMPLOYEE
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        public int USER_ID { get; set; }

        [ForeignKey("USER_ID")] public USER USER { get; set; }

        public Nullable<int> EDUCATION { get; set; }
        public Nullable<int> EXPERIENCE { get; set; }


        [NotMapped]
        public string FirstName
        {
            get => PASSPORT.FIRST_NAME;
            set => PASSPORT.FIRST_NAME = value;
        }

        [NotMapped]
        public string SecondName
        {
            get => PASSPORT.SECOND_NAME;
            set => PASSPORT.SECOND_NAME = value;
        }

        [NotMapped]
        public string FamilyName
        {
            get => PASSPORT.FAMILY_NAME;
            set => PASSPORT.FAMILY_NAME = value;
        }

        [NotMapped]
        public Education? Education => EDUCATION == null ? Commons.Education.NoEducation : (Education)EDUCATION;

        [NotMapped] public string EducationString => Education.GetEnumDescription();

        public long ITN { get; set; }

        public int PASSPORT_ID { get; set; }
        [ForeignKey("PASSPORT_ID")] public virtual PASSPORT PASSPORT { get; set; }

        public EMPLOYEE()
        {
        }

        public EMPLOYEE(PASSPORT passport)
        {
            PASSPORT = passport;
        }

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
                EDUCATION = (int?)e.Education,
                EXPERIENCE = e.Experience,
                ID = e.Id,
                ITN = e.Itn,
                PASSPORT = PASSPORT.FromTransportType(e.Passport)
            };
        }
    }
}