using System;
using System.ComponentModel.DataAnnotations.Schema;
using IntegrationLibrary.EventSourcing;

namespace IntegrationLibrary.Tendering.DomainEvents.Base
{
    [Table("tendering_events")]
    public class TenderingEvent : DomainEvent
    {
        public TenderingEvent() : base() {}
        public TenderingEvent(Guid aggregateId) : base(aggregateId) {}
        public TenderingEvent(Guid id, Guid aggregateId, string aggregateType, string eventType, DateTime timestamp) : base(id, aggregateId, aggregateType, eventType, timestamp)
        {
        }
    }
}