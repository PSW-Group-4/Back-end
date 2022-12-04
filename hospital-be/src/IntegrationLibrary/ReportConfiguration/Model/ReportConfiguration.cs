using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBanks.Model
{
    [Table("blood_banks_config")]
    public class ReportConfiguration
    {
        public Guid Id { get; set; }
        public virtual BloodBank BloodBank { get; set; }
        public ReportFrequencyTitles RequestFrequency { get; set; }
        public bool ActiveStatus { get; set; }

        public ReportConfiguration() { }
    }
}
