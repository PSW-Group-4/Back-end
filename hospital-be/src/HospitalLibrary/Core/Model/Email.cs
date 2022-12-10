using System;
using System.Text.RegularExpressions;
using HospitalLibrary.Exceptions;

namespace HospitalLibrary.Core.Model
{
    public class Email
    {
        public string Address { get; }
        private const string AddressRegex = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                               + "@"
                                               + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";

        public Email(string address)
        {
            Address = address;
            if (!IsValid())
            {
                throw new ValueObjectValidationFailedException("Email is not in proper format");
            }
        }

        private bool IsValid()
        {
            if (String.IsNullOrEmpty(Address))
            {
                return false;
            }

            var match = Regex.Match(Address, AddressRegex);
            return match.Success;
        }

        protected bool Equals(Email other)
        {
            return Address == other.Address;
        }

        public override bool Equals(object obj)   
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Email)obj);
        }

        public override int GetHashCode()
        {
            return (Address != null ? Address.GetHashCode() : 0);
        }
    }
}