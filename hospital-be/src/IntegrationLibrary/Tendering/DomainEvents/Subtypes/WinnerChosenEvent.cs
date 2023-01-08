using System;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Tendering.DomainEvents.Base;

namespace IntegrationLibrary.Tendering.DomainEvents.Subtypes
{
    public class WinnerChosenEvent : TenderingEvent
    {
        public BloodBank Winner { get; protected set; }

        public WinnerChosenEvent(Guid id, Guid aggregateId, string aggregateType, string eventType, DateTime timestamp) : base(id, aggregateId, aggregateType, eventType, timestamp)
        {
            AggregateType = "Tender";
            EventType = "WinnerChosenEvent";
        }

        public WinnerChosenEvent(Guid id, Guid aggregateId, string aggregateType, string eventType, DateTime timestamp, BloodBank winner) : base(id, aggregateId, aggregateType, eventType, timestamp)
        {
            AggregateType = "Tender";
            EventType = "WinnerChosenEvent";
            Winner = winner;
        }
        public WinnerChosenEvent(Guid aggregateId, BloodBank winner) : base(Guid.NewGuid(), aggregateId, "Tender", "WinnerChosenEvent", DateTime.Now) {
            Winner = winner;
        }
    }
}