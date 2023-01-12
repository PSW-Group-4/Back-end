using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.UrgentBloodRequestReports.Model
{
    public class UrgentBloodRequestReport
    {
        public BloodBank Bank { get; set; }
        public List<Blood> Blood { get; set; }

        public UrgentBloodRequestReport(BloodBank bank, List<Blood> blood)
        {
            Bank = bank;
            Blood = blood;
        }
    }
}
