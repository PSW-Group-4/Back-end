using System;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Tendering.DomainEvents.Base;

namespace IntegrationLibrary.Tendering.DomainEvents.Subtypes
{
    public class AppliedToTenderEvent : TenderingEvent
    {
        public BloodBank BloodBank { get; private set; }

        public AppliedToTenderEvent(Guid id, Guid aggregateId, string aggregateType, string eventType, DateTime timestamp) : base(id, aggregateId, aggregateType, eventType, timestamp)
        {
            AggregateType = "TenderApplication";
            EventType = "AppliedToTenderEvent";
        }

        public AppliedToTenderEvent(Guid id, Guid aggregateId, string aggregateType, string eventType, DateTime timestamp, BloodBank bloodBank) : base(id, aggregateId, aggregateType, eventType, timestamp)
        {
            AggregateType = "TenderApplication";
            EventType = "AppliedToTenderEvent";
            BloodBank = bloodBank;
        }
    }
}