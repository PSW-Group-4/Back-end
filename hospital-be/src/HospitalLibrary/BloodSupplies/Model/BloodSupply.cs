using IntegrationLibrary.Common;
using System;

namespace HospitalLibrary.BloodSupplies.Model
{
    public class BloodSupply
    {
        public Guid Id { get; set; }
        public BloodType BloodType { get; set; }
        public double Amount { get; set; }

        public void Update(BloodSupply bloodSupply)
        {
            Amount = bloodSupply.Amount;
        }
    }
}
