using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Common;
using IntegrationLibrary.Tenders.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegrationLibrary.TenderApplications.Model
{
    [Table("tender_applications")]
    public class TenderApplication : Entity
    {
       
        public virtual BloodBank BloodBank { get;private set; }
        public virtual Tender Tender { get; private set; }
        private Price price;   
        [JsonInclude]
        public Price Price {
            get => price ;
            private set => price = value;
        }
        public TenderApplication() { }
        public TenderApplication(BloodBank bank, Tender tender, Price price) {
            BloodBank = bank;
            CreatedDate = DateTime.Now;
            Tender = tender;
            Version = 1.0;
            Price = price;
        }
        public bool isActive()
        {
            return Tender.IsActive();
        }

    }
}
