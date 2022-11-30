using IntegrationLibrary.BloodBanks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Tenders.Model
{
    public class BloodProduct
    {
        public BloodType BloodType { get; private set; }
        public double Amount { get; private set; }

        public BloodProduct(BloodType bloodType, double amount)
        {
            BloodType = bloodType;
            Amount = amount;
        }

        public override string ToString()
        {
            return BloodType.ToString() + ' ' + Amount + "ml";
        }
    }
}
