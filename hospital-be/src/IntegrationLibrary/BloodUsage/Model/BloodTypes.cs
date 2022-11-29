using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBanks.Model
{
    public enum BloodTypeTitle
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
        public BloodTypeTitle Title { get; private set; }
        public RHFactor RHFactor { get; private set; }

        public BloodType() { }

        public BloodType(BloodTypeTitle title, RHFactor rHFactor)
        {
            this.Title = title;
            this.RHFactor = rHFactor;
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
            yield return Title;
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
