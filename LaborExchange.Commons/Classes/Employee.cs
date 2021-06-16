using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string FirstName => Passport.FirstName;

        [DisplayName("Отчество")]
        [Key(2)] public string SecondName => Passport.SecondName;

        [DisplayName("Фамилия")]
        [Key(3)] public string FamilyName => Passport.FamilyName;

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