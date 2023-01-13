using System;
using IntegrationLibrary.Tendering.DomainEvents.Base;
using IntegrationLibrary.Tendering.Model;

namespace IntegrationLibrary.Tendering.DomainEvents.Subtypes
{
    public class TenderExpiredEvent : TenderingEvent
    {
        public TenderExpiredEvent(Guid id, Guid aggregateId, string aggregateType, string eventType, DateTime timestamp) : base(id, aggregateId, aggregateType, eventType, timestamp)
        {
            AggregateType = "Tender";
            EventType = "TenderExpiredEvent";
        }
    }
}