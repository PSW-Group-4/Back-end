using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Patients.Model;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestHospitalApp.UnitTesting.VOTest
{
    public class PasswordTest
    {
        [Fact]
        public void Valid_password()
        {
            Password pass = new Password("password123");
            pass.ShouldNotBeNull();
        }

        [Fact]
        public void Invalid_password()
        {
            string password = "123";
            Should.Throw<ValueObjectValidationFailedException>(() =>
            {
                Password pass = new Password(password);
            });
        }
    }
}
