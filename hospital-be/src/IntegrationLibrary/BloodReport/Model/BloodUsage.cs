using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBanks.Model
{
    public class BloodUsage
    {
        public Guid Id { get; set; }
        public BloodType type { get; set; }
        public RHFactor rHFactor { get; set; }
        public double milliliters { get; set; }
    }
}
