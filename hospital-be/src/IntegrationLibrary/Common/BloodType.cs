using IntegrationLibrary.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace IntegrationLibrary.Common
{
    public enum BloodGroup
    {
        O,
        A,
        B,
        AB
    }
    public enum RhFactor
    {
        POSITIVE,
        NEGATIVE
    }
    public class BloodType
    {
        [JsonInclude]
        public BloodGroup BloodGroup { get; private set; }
        [JsonInclude]
        public RhFactor RhFactor { get; private set; }

        public BloodType() { }

        public BloodType(BloodGroup title, RhFactor rHFactor)
        {
            BloodGroup = title;
            RhFactor = rHFactor;
        }
        public static BloodType FromString(string type)
        {
            if (type.Contains(' '))
            {
                string[] data = new string[2];
                try
                {
                    data = type.Split(" ");
                }
                catch (IndexOutOfRangeException e)
                {

                }
                //Assumed structure of string type => BloodGroup *space* RHFactor; "A POSITIVE"
                var parseFlag1 = Enum.TryParse(data[0], true, out BloodGroup bloodGroup);
                var parseFlag2 = Enum.TryParse(data[1], true, out RhFactor rHFactor);
                if (parseFlag1 && parseFlag2)
                {
                    return new BloodType() { BloodGroup = bloodGroup, RhFactor = rHFactor };
                }
                throw new EnumToStringCastException();
            }
            else
            {
                //Assumed structure of string type => BloodGroupRHFactorAsSign; "A+"
                string bloodGroupExtracted = type[..^1];
                string rhFactorExtracted = type[^1..];
                rhFactorExtracted = rhFactorExtracted == "+" ? "POSITIVE" : rhFactorExtracted == "-" ? "NEGATIVE" : null;
                var parseFlag1 = Enum.TryParse(bloodGroupExtracted, true, out BloodGroup bloodGroup);
                var parseFlag2 = Enum.TryParse(rhFactorExtracted, true, out RhFactor rHFactor);
                if (parseFlag1 && parseFlag2)
                {
                    return new BloodType() { BloodGroup = bloodGroup, RhFactor = rHFactor };
                }
                throw new EnumToStringCastException();
            }
        }

        
        public override string ToString()
        {
            return BloodGroup.ToString() + " " + RhFactor.ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (GetType() != obj.GetType())
                throw new ArgumentException($"Invalid comparison of Value Objects of different types: {GetType()} and {obj.GetType()}");
            var valueObject = (BloodType)obj;
            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }
        //GetEqualityComponents exists so that we can use SequenceEqual to compare 2 blood types field by field 
        protected IEnumerable<object> GetEqualityComponents()
        {
            yield return BloodGroup;
            yield return RhFactor;
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
            .Aggregate(1, (current, obj) =>
            {
                return HashCode.Combine(current, obj);
            });
        }

        public static bool operator ==(BloodType a, BloodType b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            return a.Equals(b);
        }
        public static bool operator !=(BloodType a, BloodType b)
        {
            return !(a == b);
        }
    }
}
