using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;

namespace LaborExchange.Commons
{
    [Table("JOB_VACANCIES")]
    public class JOB
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("JOB_NAME")]
        public string JobName { get; set; }

        [Column("DATE_OF_OFFER")]
        public int Payment { get; set; }

        [Column("EDUCATION")]
        public Education Education { get; set; }

        [Column("EXPERIENCE")]
        public int Experience { get; set; }

        [Column("EMPLOYER")]
        public Employer Employer { get; set; }
    }
}