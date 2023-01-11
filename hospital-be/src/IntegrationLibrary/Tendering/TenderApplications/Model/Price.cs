using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace IntegrationLibrary.TenderApplications.Model
{
    public class Price
    {
        public Price() { }

        public Price(double amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        [JsonInclude] public double Amount { get; private set; }
        [JsonInclude] public string Currency { get; private set; }

        public static Price Create(double amount, string currency)
        {
            return new Price(amount, currency);
        }

        public override string ToString()
        {
            return Amount + " " + Currency;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (GetType() != obj.GetType())
                throw new ArgumentException(
                    $"Invalid comparison of Value Objects of different types: {GetType()} and {obj.GetType()}");
            Price valueObject = (Price)obj;
            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        protected IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return Currency;
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate(1, (current, obj) => { return HashCode.Combine(current, obj); });
        }

        public static bool operator ==(Price a, Price b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(Price a, Price b)
        {
            return !(a == b);
        }

        public static bool IsValid(Price price)
        {
            bool valid = false;
            if (price.Amount > 0)
                if (!(price.Currency.Contains("0") || price.Currency.Contains("1") || price.Currency.Contains("2") ||
                      price.Currency.Contains("3") || price.Currency.Contains("4") || price.Currency.Contains("5") ||
                      price.Currency.Contains("6") || price.Currency.Contains("7") || price.Currency.Contains("8") ||
                      price.Currency.Contains("9")))
                    valid = true;

            return valid;
        }
    }
}