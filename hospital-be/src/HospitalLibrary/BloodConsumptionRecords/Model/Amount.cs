using HospitalLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.BloodConsumptionRecords.Model
{
    public class Amount
    {
        public double Value { get; }

        public Amount (double value)
        {
            Value = value;
            if (!IsValid()) throw new ValueObjectValidationFailedException("Amount must have positive value!");
        }

        private bool IsValid()
        {
            return Value >= 0;
        }

        protected bool Equals(Amount other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Amount)obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
