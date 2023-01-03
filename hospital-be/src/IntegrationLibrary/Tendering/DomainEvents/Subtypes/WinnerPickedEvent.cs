using System;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Tendering.DomainEvents.Base;

namespace IntegrationLibrary.Tendering.DomainEvents.Subtypes
{
    public class WinnerPickedEvent : TenderingEvent
    {
        public BloodBank Winner { get; protected set; }

        public WinnerPickedEvent(Guid id, Guid aggregateId, string aggregateType, string eventType, DateTime timestamp) : base(id, aggregateId, aggregateType, eventType, timestamp)
        {
            AggregateType = "Tender";
            EventType = "WinnerPickedEvent";
        }

        public WinnerPickedEvent(Guid id, Guid aggregateId, string aggregateType, string eventType, DateTime timestamp, BloodBank winner) : base(id, aggregateId, aggregateType, eventType, timestamp)
        {
            AggregateType = "Tender";
            EventType = "WinnerPickedEvent";
            Winner = winner;
        }
    }
}