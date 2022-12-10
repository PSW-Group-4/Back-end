using System;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Users.Model;
using Shouldly;
using Xunit;

namespace TestHospitalApp.UnitTesting.VOTest
{
    public class EmailTest
    {
        [Fact]
        public void Valid_email()
        {
            string emailAddress = "john@gmail.com";

            Email email = new Email(emailAddress);
            
            email.ShouldNotBeNull();   
        }
        
        [Fact]
        public void Invalid_email_doesnt_have_at_sign()
        {
            string emailAddress = "johngmail.com";

            Should.Throw<ValueObjectValidationFailedException>(() =>
            {
                Email email = new Email(emailAddress);
            });
        }
        
        [Fact]
        public void Invalid_email_doesnt_have_domain()
        {
            string emailAddress = "john@gmail";

            Should.Throw<ValueObjectValidationFailedException>(() =>
            {
                Email email = new Email(emailAddress);
            });
        }
        
        [Fact]
        public void Emails_are_equal()
        {
            Email email1 = new Email("john@gmail.com");
            Email email2 = new Email("john@gmail.com");

            var result = email1.Equals(email2);
            
            result.ShouldBeTrue();

        }

        [Fact]
        public void Emails_are_not_equal()
        {
            Email email1 = new Email("john@gmail.com");
            Email email2 = new Email("helen@gmail.com");

            var result = email1.Equals(email2);
            
            result.ShouldBeFalse();

        }

    }
}