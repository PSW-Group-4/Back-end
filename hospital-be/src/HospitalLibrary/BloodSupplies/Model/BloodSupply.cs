using System;

namespace HospitalLibrary.BloodSupplies.Model
{
    public class BloodSupply
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public double Amount { get; set; }

        public void Update(BloodSupply bloodSupply)
        {
            Amount = bloodSupply.Amount;
        }
    }
}
