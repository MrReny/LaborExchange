using System.ComponentModel;
using MessagePack;

namespace LaborExchange.Commons
{
    [MessagePackObject]
    public class Job
    {
        [Key(0)]
        [Browsable(false)]
        public int Id { get; set; }

        [Key(1)]
        [DisplayName("Наименование")]
        public string JobName { get; set; }

        [Key(2)]
        [DisplayName("Зарплата")]
        public int? Payment { get; set; }

        [Key(3)]
        [Browsable(false)]
        public Education Education { get; set; }

        [IgnoreMember]
        [DisplayName("Оброзование")]
        public string EducationString => Education.GetEnumDescription(); //TODO КОЛХОЗИЩЕ

        [Key(4)]
        [DisplayName("Опыт")]
        public int Experience { get; set; }

        [Key(5)]
        [Browsable(false)]
        public Employer Employer { get; set; }

        [IgnoreMember]
        [DisplayName("Работодатель")]
        public string EmployerName => Employer.LegalName;

        [IgnoreMember]
        [DisplayName("Тип работодателя")]
        public string EmployerType => Employer.Type.GetEnumDescription();

    }
}