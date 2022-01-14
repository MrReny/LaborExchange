using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaborExchange.Server.DBModel
{
    [Table("USERS")]
    public class USER
    {
        [Key] public int ID { get; set; }
        public string LOGIN { get; set; }
        public string PASSWORD { get; set; }
        public string EMAIL { get; set; }
        public int USER_TYPE { get; set; }

        public DateTime CREATED { get; set; }

        public EMPLOYEE Employee { get; set; }

        public EMPLOYER Employer { get; set; }
    }
}