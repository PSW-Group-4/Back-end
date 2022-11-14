using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBanks.Model
{
    [Table("blood_usage")]
    public class BloodUsage
    {
        public Guid Id { get; set; }
        public BloodType Type { get; set; }
        public RHFactor RHFactor { get; set; }
        public double Milliliters { get; set; }
    }
}
