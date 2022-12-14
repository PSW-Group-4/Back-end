using System;
using System.Text.RegularExpressions;
using IntegrationLibrary.Exceptions;

namespace IntegrationLibrary.BloodBanks.Model
{
    public class ApiKey
    {
        public string ApiKeyValue { get; }
        private const string ApiKeyRegex = @"[0-9A-Za-z-_]{35}";
        public ApiKey(string apiKey)
        {
            ApiKeyValue = apiKey;
            if (!IsValid())
            {
                throw new ValueObjectValidationFailedException("Api key is not in proper format");
            }
        }

        public bool IsValid()
        {
            if (String.IsNullOrEmpty(ApiKeyValue))
            {
                return false;
            }

            var match = Regex.Match(ApiKeyValue, ApiKeyRegex);
            return match.Success;
        }

        protected bool Equals(ApiKey other)
        {
            return ApiKeyValue == other.ApiKeyValue;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ApiKey)obj);
        }

        public override int GetHashCode()
        {
            return (ApiKeyValue != null ? ApiKeyValue.GetHashCode() : 0);
        }

    }
}
