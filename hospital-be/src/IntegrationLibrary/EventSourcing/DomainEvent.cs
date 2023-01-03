using System;

namespace IntegrationLibrary.EventSourcing
{
    public abstract class DomainEvent
    {
        public Guid Id { get; private set; }
        public Guid AggregateId { get; private set; }
        public DateTime Timestamp { get; private set; }
        
        
        public DomainEvent(Guid aggregateId, DateTime timestamp)
        {
            AggregateId = aggregateId;
            Timestamp = timestamp;
        }

    }
}