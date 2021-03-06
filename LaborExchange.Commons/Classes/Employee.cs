using System.ComponentModel;
using MessagePack;

namespace LaborExchange.Commons
{

    [MessagePackObject]
    public class Employee
    {
        [Browsable(false)]
        [Key(0)]
        public int Id { get; set; }

        [Browsable(false)]
        [IgnoreMember]
        public int? UserId { get; set; }

        [DisplayName("Имя")]
        [Key(1)]
        public string FirstName
        {
            get => Passport.FirstName;
            set => Passport.FirstName = value;
        }

        [DisplayName("Отчество")]
        [Key(2)] public string SecondName
        {
            get => Passport.SecondName;
            set => Passport.SecondName = value;
        }

        [DisplayName("Фамилия")]
        [Key(3)] public string FamilyName
        {
            get => Passport.FamilyName;
            set => Passport.FamilyName = value;
        }

        [Browsable(false)]
        [Key(4)]
        public Education? Education { get; set; }

        [DisplayName("Образование")]
        [IgnoreMember]
        //TODO добавить конверторы колонок и избавиться от этого стыда
        public string EducationString => Education.GetEnumDescription();

        [DisplayName("Опыт")]
        [Key(5)]
        public int? Experience { get; set; }

        [Browsable(false)]
        [Key(6)]
        public long Itn { get; set; }

        [Browsable(false)]
        [Key(7)]
        public Passport Passport { get; set; }
    }
}