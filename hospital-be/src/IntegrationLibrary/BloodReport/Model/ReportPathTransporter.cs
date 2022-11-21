using IntegrationLibrary.BloodBanks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodReport.Model
{
    public class ReportPathTransporter
    {
        public BloodUsageReport Report { get; set; }
        public string ReportPath { get; set; }
    }
}
