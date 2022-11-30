using IntegrationLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBanks.Model
{
    public enum BloodGroup
    {
        O,
        A,
        B,
        AB
    }
    public enum RHFactor
    {
        POSITIVE,
        NEGATIVE
    }
    public class BloodType
    {
        public BloodGroup BloodGroup { get; private set; }
        public RHFactor RHFactor { get; private set; }

        public BloodType() { }

        public BloodType(BloodGroup title, RHFactor rHFactor)
        {
            this.BloodGroup = title;
            this.RHFactor = rHFactor;
        }
        public static BloodType FromString(string type)
        {
            string[] data=new string[2];
            try
            {
                data = type.Split(" ");
            }
            catch(IndexOutOfRangeException e)
            {
                
            }
            //Assumed structure of string type => BloodGroup *space* RHFactor; "A POSITIVE"
            var parseFlag1 = Enum.TryParse<BloodGroup>(data[0], true, out BloodGroup bloodGroup);
            var parseFlag2 = Enum.TryParse<RHFactor> (data[1], true, out RHFactor rHFactor);
            if (parseFlag1 && parseFlag2)
            {
                return new BloodType() { BloodGroup = bloodGroup, RHFactor = rHFactor };
            }
            throw new EnumToStringCastException();
        }
        public override string ToString()
        {
            return BloodGroup.ToString() + " " + RHFactor.ToString();
        }
        public override bool Equals(object obj)
        {
           if(obj == null) return false;

            if (GetType() != obj.GetType())
                throw new ArgumentException($"Invalid comparison of Value Objects of different types: {GetType()} and {obj.GetType()}");
            var valueObject = (BloodType)obj;
            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }
        //GetEqualityComponents exists so that we can use SequenceEqual to compare 2 blood types field by field 
        protected IEnumerable<object> GetEqualityComponents()
        {
            yield return BloodGroup;
            yield return RHFactor;
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
