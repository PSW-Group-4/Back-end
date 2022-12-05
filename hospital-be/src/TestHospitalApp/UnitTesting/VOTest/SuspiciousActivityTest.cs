using HospitalLibrary.Exceptions;
using HospitalLibrary.Users.Model;
using Shouldly;
using System;
using Xunit;

namespace TestHospitalApp.UnitTesting.VOTest
{
    public class SuspiciousActivityTest
    {

        [Fact]
        public void Valid_suspicious_activity()
        {
            SuspiciousActivity suspiciousActivity = new SuspiciousActivity("TEST", DateTime.Now);
            suspiciousActivity.ShouldNotBe(null);
        }

        [Fact]
        public void Suspicious_activity_invalid_date()
        {
            Should.Throw<ValueObjectValidationFailedException>(() => new SuspiciousActivity("TEST", DateTime.Now.AddDays(1)));
        }


        [Fact]
        public void Suspicious_activity_invalid_activity_name()
        {
            Should.Throw<ValueObjectValidationFailedException>(() => new SuspiciousActivity("", DateTime.Now));
        }


    }
}
