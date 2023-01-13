using IntegrationAPI.Dtos.BloodProducts;
using IntegrationLibrary.BloodBanks.Model;
using System;
using System.Collections;
using System.Collections.Generic;

namespace IntegrationAPI.Dtos.Tenders
{
    public class TenderDto
    {
        public List<BloodDto> Blood { get; set; }
        public String Deadline { get; set; }
    }
}
