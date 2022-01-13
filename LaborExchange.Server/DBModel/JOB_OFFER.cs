using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LaborExchange.Commons;

namespace LaborExchange.Server.DBModel
{


    public class JOB_OFFER
    {
        [Key]
        public int ID { get; set; }

        public int JOB_ID { get; set; }
        [ForeignKey("JOB_ID")]
        public JOB_VACANCY JobVacancy { get; set; }


        public int EMPLOYEE_ID { get; set; }
        [ForeignKey("EMPLOYEE_ID")]
        public EMPLOYEE Employee { get; set; }

        public System.DateTime DATE_OF_OFFER { get; set; }
        public Nullable<int> STATE { get; set; }
        public int INITIATOR_TYPE { get; set; }

        public JobOffer ToTransportType()
        {
            return new JobOffer()
            {
                Id = ID,
                JobId = JOB_ID,
                DateOfOffer = DATE_OF_OFFER,
                EmployeeId = EMPLOYEE_ID,
                Initiator = (OfferInitiator)INITIATOR_TYPE,
                Status = STATE==null? OfferStatus.NotReviewed : (OfferStatus)STATE
            };
        }

        public static JOB_OFFER FromTransportType(JobOffer j)
        {
            return new JOB_OFFER()
            {
                ID = j.Id,
                JOB_ID = j.JobId,
                DATE_OF_OFFER = j.DateOfOffer,
                EMPLOYEE_ID = j.EmployeeId,
                INITIATOR_TYPE = (int)j.Initiator,
                STATE = (int)j.Status
            };
        }



    }
}
