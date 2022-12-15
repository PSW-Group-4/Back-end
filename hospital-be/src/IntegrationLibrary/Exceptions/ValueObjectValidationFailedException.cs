using System;

namespace IntegrationLibrary.Exceptions
{
    public class ValueObjectValidationFailedException: Exception
    {
        public ValueObjectValidationFailedException() { }

        public ValueObjectValidationFailedException(string message) : base(message) { }
    }
}
