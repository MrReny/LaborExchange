using System;
using MessagePack;

namespace LaborExchange.Commons
{
    [MessagePackObject]
    public class JobOffer
    {
        [Key(0)]
        public int Id { get; set; }

        [Key(1)]
        public int JobId { get; set; }

        [Key(2)]
        public int EmployeeId { get; set; }

        [Key(3)]
        public DateTime DateOfOffer { get; set; }

        [Key(4)]
        public OfferStatus Status { get; set; }

        [Key(5)]
        public OfferInitiator Initiator { get; set; }
    }
}