using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegrationLibrary.EventSourcing
{
    [NotMapped]
    public abstract class DomainEvent
    {
        public Guid Id { get; protected set; }
        public Guid AggregateId { get; protected set; }
        public string AggregateType { get; protected set; }
        public string EventType { get; protected set; }
        public DateTime Timestamp { get; protected set; }

        public DomainEvent()
        {
            Id = Guid.NewGuid();
            Timestamp = DateTime.Now;
        }

        public DomainEvent(Guid aggregateId)
        {
            Id = Guid.NewGuid();
            Timestamp = DateTime.Now;
            AggregateId = aggregateId;
        }

        public DomainEvent(Guid id, Guid aggregateId, string aggregateType, string eventType, DateTime timestamp)
        {
            Id = id;
            AggregateId = aggregateId;
            AggregateType = aggregateType;
            EventType = eventType;
            Timestamp = timestamp;
        }
    }
}