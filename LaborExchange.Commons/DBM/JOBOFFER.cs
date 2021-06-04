using System;
using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;

namespace LaborExchange.Commons
{
    [Table("JOB_OFFERS")]
    public class JOBOFFER
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("JOB_ID")]
        public int JobId { get; set; }

        [Column("EMPLOYEE_ID")]
        public int EmployeeId { get; set; }

        [Column("DATE_OF_OFFER")]
        public DateTime DateOfOffer { get; set; }

        [Column("STATE")]
        public OfferStatus Status { get; set; }

        [Column("INITIATOR_TYPE")]
        public OfferInitiator Initiator { get; set; }
    }
}