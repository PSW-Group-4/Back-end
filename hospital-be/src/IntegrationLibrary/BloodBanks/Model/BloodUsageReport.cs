using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBanks.Model
{
    [Table("blood_usage_report")]
    public class BloodUsageReport
    {
        public Guid Id { get; set; }
        public BloodBank BloodBank { get; set; }
        public ReportConfiguration ReportConfiguration { get; set; }
        public List<BloodUsage> BloodUsage { get; set; }
    }
}
