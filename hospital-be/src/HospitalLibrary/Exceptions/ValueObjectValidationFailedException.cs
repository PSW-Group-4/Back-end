using System;

namespace HospitalLibrary.Exceptions
{
    public class ValueObjectValidationFailedException: Exception
    {
       public ValueObjectValidationFailedException(){}

       public ValueObjectValidationFailedException(string message) :base(message){}
        
    }
}