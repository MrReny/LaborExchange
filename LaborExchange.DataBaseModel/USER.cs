using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaborExchange.DataBaseModel
{
    [Table("USERS")]
    public class USER
    {
        [Key]
        public int ID { get; set; }
        public string LOGIN { get; set; }
        public string PASSWORD { get; set; }
        public string EMAIL { get; set; }
        public int USER_TYPE { get; set; }
    }
}
