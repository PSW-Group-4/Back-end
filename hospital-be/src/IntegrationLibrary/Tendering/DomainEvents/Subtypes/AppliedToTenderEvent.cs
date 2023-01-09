using System;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.TenderApplications.Model;
using IntegrationLibrary.Tendering.DomainEvents.Base;
using IntegrationLibrary.Tendering.Model;

namespace IntegrationLibrary.Tendering.DomainEvents.Subtypes
{
    public class AppliedToTenderEvent : TenderingEvent
    {
        public BloodBank BloodBank { get; private set; }
        public Tender Tender { get; private set; }
        public Price Price { get; private set; }

        public AppliedToTenderEvent(BloodBank bloodBank, Tender tender, Price price) : base()
        {
            AggregateType = "TenderApplication";
            EventType = "AppliedToTenderEvent";
            BloodBank = bloodBank;
            Tender = tender;
            Price = price;
        }
        public AppliedToTenderEvent(Guid id, Guid aggregateId, string aggregateType, string eventType, DateTime timestamp) : base(id, aggregateId, aggregateType, eventType, timestamp)
        {
            AggregateType = "TenderApplication";
            EventType = "AppliedToTenderEvent";
        }

        public AppliedToTenderEvent(Guid id, Guid aggregateId, string aggregateType, string eventType, DateTime timestamp, BloodBank bloodBank, Tender tender, Price price) : base(id, aggregateId, aggregateType, eventType, timestamp)
        {
            AggregateType = "TenderApplication";
            EventType = "AppliedToTenderEvent";
            BloodBank = bloodBank;
            Tender = tender;
            Price = price;
        }
    }
}