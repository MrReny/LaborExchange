using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;

namespace LaborExchange.Commons
{
    [MessagePackObject]
    public class Job
    {
        [Key(0)]
        public int Id { get; set; }

        [Key(1)]
        public string JobName { get; set; }

        [Key(2)]
        public int? Payment { get; set; }

        [Key(3)]
        public Education Education { get; set; }

        [Key(4)]
        public int Experience { get; set; }

        [Key(5)]
        public Employer Employer { get; set; }
    }
}