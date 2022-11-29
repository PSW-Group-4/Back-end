using IntegrationLibrary.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace IntegrationLibrary.Common
{
    public class EmailAddress : IComparable<EmailAddress>, IEquatable<EmailAddress>
    {
        public String LocalPart { get; private set; }
        public String Domain { get; private set; }

        private EmailAddress(string localPart, string domain)
        {LocalPart = localPart;
            Domain = domain;
            
        }

        public static EmailAddress Create(String input)
        {
            if(IsValid(input))
            {
                return new EmailAddress(input.Split('@')[0], input.Split('@')[1]);
            } else
            {
                throw new InvalidEmailFormat();
            }
        }

        public static bool IsValid(String input)
        {
            return Regex.IsMatch(input.Trim(), @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        public override string ToString()
        {
            return LocalPart + '@' + Domain;
        }

        public bool Equals(EmailAddress other)
        {
            return CompareTo(other) == 0;
        }

        public bool Equals(string other)
        {
            return CompareTo(other) == 0;
        }

        public int CompareTo(EmailAddress other)
        {
            return String.Compare(ToString(), other.ToString(), StringComparison.OrdinalIgnoreCase);
        }

        public int CompareTo(string other)
        {
            return String.Compare(ToString(), other, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            return obj is EmailAddress emailAddress && Equals(emailAddress);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(LocalPart, Domain);
        }
        public static bool operator ==(EmailAddress leftHandValue, EmailAddress rightHandValue) => leftHandValue.Equals(rightHandValue);
        public static bool operator ==(EmailAddress leftHandValue, String rightHandValue) => leftHandValue.Equals(rightHandValue);
        public static bool operator !=(EmailAddress leftHandValue, EmailAddress rightHandValue) => !leftHandValue.Equals(rightHandValue);
        public static bool operator !=(EmailAddress leftHandValue, String rightHandValue) => !leftHandValue.Equals(rightHandValue);

        public static bool operator <(EmailAddress left, EmailAddress right)
        {
            return left is null ? right is not null : left.CompareTo(right) < 0;
        }

        public static bool operator <=(EmailAddress left, EmailAddress right)
        {
            return left is null || left.CompareTo(right) <= 0;
        }

        public static bool operator >(EmailAddress left, EmailAddress right)
        {
            return left is not null && left.CompareTo(right) > 0;
        }

        public static bool operator >=(EmailAddress left, EmailAddress right)
        {
            return left is null ? right is null : left.CompareTo(right) >= 0;
        }
    }
}
