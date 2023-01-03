using System;
using IntegrationLibrary.Tendering.DomainEvents.Base;
using IntegrationLibrary.Tendering.Model;

namespace IntegrationLibrary.Tendering.DomainEvents.Subtypes
{
    public class TenderClosedEvent : TenderingEvent
    {
        public TenderStatus Status { get; private set; }

        public TenderClosedEvent(Guid id, Guid aggregateId, string aggregateType, string eventType, DateTime timestamp) : base(id, aggregateId, aggregateType, eventType, timestamp)
        {
            AggregateType = "Tender";
            EventType = "TenderClosedEvent";
        }

        public TenderClosedEvent(Guid id, Guid aggregateId, string aggregateType, string eventType, DateTime timestamp, TenderStatus status) : base(id, aggregateId, aggregateType, eventType, timestamp)
        {
            AggregateType = "Tender";
            EventType = "TenderClosedEvent";
            Status = status;
        }
    }
}