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

        public override void Apply(DomainEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
