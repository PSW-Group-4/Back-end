﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dtos.TenderApplications
{
    public class ApplyForTenderDto
    {
        public Guid BloodBankId { get; set; }
        public Guid TenderId { get; set; }
        public double PriceInRSD { get; set; }
    }
}