using System;
using System.Collections.Generic;
using IntegrationLibrary.Common;
using IntegrationLibrary.Tendering.DomainEvents.Base;

namespace IntegrationLibrary.Tendering.DomainEvents.Subtypes
{
    public class TenderCreatedEvent : TenderingEvent
    {
        public List<Blood> Blood { get; private set; }
        public DateTime? Deadline { get; private set; }

        public TenderCreatedEvent(Guid id, Guid aggregateId, string aggregateType, string eventType, DateTime timestamp)
            : base(id, aggregateId, aggregateType, eventType, timestamp)
        {
            AggregateType = "Tender";
            EventType = "TenderCreatedEvent";
        }

        public TenderCreatedEvent(List<Blood> blood, DateTime? deadline) : base()
        {
            AggregateType = "Tender";
            EventType = "TenderCreatedEvent";
            Blood = blood;
            Deadline = deadline;
        }

        public TenderCreatedEvent(Guid id, Guid aggregateId, string aggregateType, string eventType, DateTime timestamp,
            List<Blood> blood, DateTime deadline) : base(id, aggregateId, aggregateType, eventType, timestamp)
        {
            AggregateType = "Tender";
            EventType = "TenderCreatedEvent";
            Blood = blood;
            Deadline = deadline;
        }
    }
}