using IntegrationLibrary.TenderApplications.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dtos.TenderApplications
{
    public class ApplyForTenderDto
    {
        public String BloodBank { get; set; }
        public Guid TenderId { get; set; }
        public Double PriceInRSD { get; set; }
    }
}
