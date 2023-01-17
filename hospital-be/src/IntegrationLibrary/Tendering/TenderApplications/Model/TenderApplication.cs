using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using IntegrationLibrary.EventSourcing;
using IntegrationLibrary.Tendering.DomainEvents.Subtypes;
using IntegrationLibrary.Tendering.Model;

namespace IntegrationLibrary.TenderApplications.Model
{
    [Table("tender_applications")]
    public class TenderApplication : AggregateRoot
    {
        public virtual BloodBank BloodBank { get;private set; }
        public virtual Tender Tender { get; private set; }
        public Price Price { get; private set; }
        public TenderApplication() { }
        public TenderApplication(BloodBank bank, Tender tender, Price price) {
            BloodBank = bank;
            CreatedDate = DateTime.Now;
            Tender = tender;
            Version = 1.0;
            Price = price;
        }

        private void AddEvent(DomainEvent @event)
        {
        }
        public void Causes(DomainEvent @event)
        {
            Apply(@event);
            AddEvent(@event);
        }
        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
            Modify();
        }
        
        private void When(AppliedToTenderEvent appliedToTenderEvent)
        {
            BloodBank = appliedToTenderEvent.BloodBank;
            Tender = appliedToTenderEvent.Tender;
            Price = appliedToTenderEvent.Price;
        }
    }
}
