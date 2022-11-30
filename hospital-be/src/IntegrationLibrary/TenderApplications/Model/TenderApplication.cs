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
        public Guid BloodBankId { get; set; }
        public Guid TenderId { get; set; }
        public double PriceInRSD { get; set; }
    }
}
