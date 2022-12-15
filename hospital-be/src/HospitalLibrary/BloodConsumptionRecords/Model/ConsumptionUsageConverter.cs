using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.BloodConsumptionRecords.Model
{
    public class ConsumptionUsageConverter
    {
        public static BloodUsage Convert(BloodConsumptionRecord record)
        {
            BloodUsage usage = new BloodUsage();
            usage.TimeStamp = record.DateTime;
            usage.Milliliters = record.Amount.Value;
            usage.Type = BloodType.FromString(record.BloodType);
            return usage;
        } 
    }
}
