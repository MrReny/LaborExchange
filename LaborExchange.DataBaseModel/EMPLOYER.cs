using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LaborExchange.Commons;

namespace LaborExchange.DataBaseModel
{
    public class EMPLOYER
    {
        [Key]
        public int ID { get; set; }

        public int USER_ID { get; set; }

        [ForeignKey("USER_ID")]
        public USER User { get; set; }

        public short EMPLOYER_TYPE { get; set; }
        public string LEGAL_NAME { get; set; }

        public ICollection<JOB_VACANCY> Jobs { get; set; }

        [NotMapped]
        public LEGAL_ENTITY LegalEntity { get; set; }

        [NotMapped]
        public SOLE_PROPRITEOR SoleProprietor { get; set; }

        #region Methods

        public Employer ToTransportType()
        {
            return new Employer()
            {
                Id = ID,
                UserId = USER_ID,
                Type = (EmployerType)EMPLOYER_TYPE,
                LegalName = LEGAL_NAME
            };
        }

        public static EMPLOYER FromTransportType(Employer e)
        {
            return new EMPLOYER()
            {
                ID = e.Id,
                USER_ID = e.UserId,
                User = null,
                EMPLOYER_TYPE = (short)e.Type,
                LEGAL_NAME = e.LegalName
            };
        }

        #endregion

    }
}
