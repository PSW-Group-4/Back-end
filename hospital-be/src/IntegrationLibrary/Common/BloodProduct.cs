using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegrationLibrary.Common
{
    public class BloodProduct
    {

        [JsonInclude]
        public BloodType BloodType { get; private set; }

        [JsonInclude]
        public double Amount { get; private set; }

        public BloodProduct(BloodType bloodType, double amount)
        {
            BloodType = bloodType;
            Amount = amount;
        }

        public BloodProduct(BloodGroup bloodGroup, RHFactor rhFactor, double amount)
        {
            BloodType = new BloodType(bloodGroup, rhFactor);
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
