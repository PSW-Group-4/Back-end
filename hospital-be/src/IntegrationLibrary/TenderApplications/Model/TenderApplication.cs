using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Tenders.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.TenderApplications.Model
{
    public class TenderApplication
    {
        [Key]
        public Guid ApplicationId { get; set; }
        public virtual BloodBank BloodBank { get; set; }
        public virtual Tender Tender { get; set; }
        public double PriceInRSD { get; set; }
    }
}
