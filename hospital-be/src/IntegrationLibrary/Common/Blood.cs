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
    public class Blood
    {
        [JsonInclude]
        public BloodType BloodType { get; private set; }

        [JsonInclude]
        public double Amount { get; private set; }

        public Blood(BloodType bloodType, double amount)
        {
            BloodType = bloodType;
            Amount = amount;
        }

        public Blood(BloodGroup bloodGroup, RhFactor rhFactor, double amount)
        {
            BloodType = new BloodType(bloodGroup, rhFactor);
            Amount = amount;
        }

        public Blood() { }

        public override string ToString()
        {
            return BloodType.ToString() + "," + Amount;
        }

        public static Blood FromString(string input)
        {
            var splitted = input.Split(',');
            return new Blood(BloodType.FromString(splitted[0]), double.Parse(splitted[1]));
        }
    }
}
