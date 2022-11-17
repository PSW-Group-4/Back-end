using IntegrationLibrary.BloodBanks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodUsages.Model
{
    public class BloodUsageDto
    {
        public BloodType Type { get; set; }
        public RHFactor RHFactor { get; set; }
        public double Milliliters { get; set; }
    }
}
