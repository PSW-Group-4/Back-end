using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Common;

namespace IntegrationLibrary.BloodBanks.Model
{
    [Table("blood_usage")]
    public class BloodUsage
    {
        public Guid Id { get; set; }
        public virtual BloodType Type { get; set; }
        public double Milliliters { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
