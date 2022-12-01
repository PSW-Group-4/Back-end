using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Common
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

        public BloodProduct() { }

        public override string ToString()
        {
            return BloodType.ToString() + "," + Amount;
        }

        public static BloodProduct FromString(String input)
        {
            var splitted = input.Split(',');
            return new BloodProduct(BloodType.FromString(splitted[0]), Double.Parse(splitted[1]));
        }
    }
}
