using System;
using IntegrationLibrary.Tendering.DomainEvents.Base;

namespace IntegrationLibrary.Tendering.DomainEvents.Subtypes
{
    public class WinnerConfirmedEvent : TenderingEvent
    {
        public WinnerConfirmedEvent(Guid aggregateId) : base(aggregateId)
        {
            AggregateType = "Tender";
            EventType = "WinnerChosenEvent";
        }
        public WinnerConfirmedEvent(Guid id, Guid aggregateId, string aggregateType, string eventType, DateTime timestamp) : base(id, aggregateId, aggregateType, eventType, timestamp)
        {
            AggregateType = "Tender";
            EventType = "WinnerChosenEvent";
        }
    }
}