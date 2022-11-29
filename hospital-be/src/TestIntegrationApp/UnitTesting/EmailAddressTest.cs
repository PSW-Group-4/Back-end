using IntegrationLibrary.Common;
using IntegrationLibrary.Exceptions;
using Org.BouncyCastle.Crypto.Macs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestIntegrationApp.UnitTesting
{
    public class EmailAddressTest
    {
        [Fact]
        public void Email_Address_Is_Valid()
        {
            String input = "adresica@gmail.com";
            
            bool result = EmailAddress.IsValid(input);

            Assert.True(result);
        }

        [Fact]
        public void Email_Address_Is_Not_Valid_1()
        {
            String input = "adresica@";

            bool result = EmailAddress.IsValid(input);

            Assert.False(result);
        }

        [Fact]
        public void Email_Address_Is_Not_Valid_2()
        {
            String input = "@gmail.com";

            bool result = EmailAddress.IsValid(input);

            Assert.False(result);
        }

        [Fact]
        public void Email_Address_Is_Not_Valid_3()
        {
            String input = "adresicagmailcom";

            bool result = EmailAddress.IsValid(input);

            Assert.False(result);
        }

        [Fact]
        public void Email_Address_Is_Created_From_String()
        {
            EmailAddress addressFromInput = new("adresica@gmail.com");

            var result = addressFromInput.LocalPart == "adresica" && addressFromInput.Domain == "gmail.com";

            Assert.True(result);
        }

        [Fact]
        public void Invalid_Email_Address_Creation_Throws_Exception()
        {
            EmailAddress addressFromInput = new("adresica@gmail.com");

            Assert.Throws<InvalidEmailFormat>(() => new EmailAddress("adresicagmailcom"));
        }

        [Fact]
        public void Equality_Check()
        {
            String input = "adresica@gmail.com";
            EmailAddress addressFromInput = new(input);

            var result = addressFromInput.Equals(input);

            Assert.True(result);
        }

        [Fact]
        public void Equality_Check_2()
        {
            EmailAddress first = new("adresica@gmail.com");
            EmailAddress second = new("adresica@gmail.com");

            var result = first.Equals(second);

            Assert.True(result);
        }

        [Fact]
        public void Equality_Check_3()
        {
            String input = "adresica@gmail.com";
            EmailAddress addressFromInput = new(input);

            var result = addressFromInput == input;

            Assert.True(result);
        }

        [Fact]
        public void Equality_Check_4()
        {
            EmailAddress first = new("adresica@gmail.com");
            EmailAddress second = new("adresica@gmail.com");

            var result = first == second;

            Assert.True(result);
        }

        [Fact]
        public void Inequality_Check()
        {
            String input = "adresica@gmail.com";
            EmailAddress address = new("adresicaa@gmail.com");

            var result = address.Equals(input);

            Assert.False(result);
        }

        [Fact]
        public void Inquality_Check_2()
        {
            EmailAddress first = new("adresica@gmail.com");
            EmailAddress second = new("adresicaa@gmail.com");

            var result = first.Equals(second);

            Assert.False(result);
        }

        [Fact]
        public void Inequality_Check_3()
        {
            String input = "adresica@gmail.com";
            EmailAddress address = new("adresicaa@gmail.com");

            var result = address != input;

            Assert.True(result);
        }

        [Fact]
        public void Inequality_Check_4()
        {
            EmailAddress first = new("adresica@gmail.com");
            EmailAddress second = new("adresicaa@gmail.com");

            var result = first != second;

            Assert.True(result);
        }
    }
}
