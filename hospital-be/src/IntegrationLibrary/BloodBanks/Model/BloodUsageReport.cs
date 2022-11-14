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
        public virtual BloodBank BloodBank { get; set; }
        public virtual ReportConfiguration ReportConfiguration { get; set; }
        public virtual List<BloodUsage> BloodUsage { get; set; }
        public DateTime TimeOfCreation { get; set; }
    }
}
