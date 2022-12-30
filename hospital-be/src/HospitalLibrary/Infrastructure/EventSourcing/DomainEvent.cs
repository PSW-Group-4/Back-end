using System;

namespace HospitalLibrary.Infrastructure.EventSourcing
{
    public abstract class DomainEvent
    {
        public Guid Id { get; private set; }
        public Guid AggregateId { get; private set; }
        public DateTime OccurrenceTime { get; private set; }
        
        
        public DomainEvent(Guid aggregateId, DateTime occurrenceTime)
        {
            AggregateId = aggregateId;
            OccurrenceTime = occurrenceTime;
        }

    }
}
