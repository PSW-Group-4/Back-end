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
            EmailAddress addressFromInput = EmailAddress.Create("adresica@gmail.com");

            var result = addressFromInput.LocalPart == "adresica" && addressFromInput.Domain == "gmail.com";

            Assert.True(result);
        }

        [Fact]
        public void Invalid_Email_Address_Creation_Throws_Exception()
        {

            Assert.Throws<InvalidEmailFormatException>(() => EmailAddress.Create("adresicagmailcom"));
        }

        [Fact]
        public void Equality_Check()
        {
            String input = "adresica@gmail.com";
            EmailAddress addressFromInput = EmailAddress.Create(input);

            var result = addressFromInput.Equals(input);

            Assert.True(result);
        }

        [Fact]
        public void Equality_Check_2()
        {
            EmailAddress first = EmailAddress.Create("adresica@gmail.com");
            EmailAddress second = EmailAddress.Create("adresica@gmail.com");

            var result = first.Equals(second);

            Assert.True(result);
        }

        [Fact]
        public void Equality_Check_3()
        {
            String input = "adresica@gmail.com";
            EmailAddress addressFromInput = EmailAddress.Create(input);

            var result = addressFromInput == input;

            Assert.True(result);
        }

        [Fact]
        public void Equality_Check_4()
        {
            EmailAddress first = EmailAddress.Create("adresica@gmail.com");
            EmailAddress second = EmailAddress.Create("adresica@gmail.com");

            var result = first == second;

            Assert.True(result);
        }

        [Fact]
        public void Inequality_Check()
        {
            String input = "adresica@gmail.com";
            EmailAddress address = EmailAddress.Create("adresicaa@gmail.com");

            var result = address.Equals(input);

            Assert.False(result);
        }

        [Fact]
        public void Inquality_Check_2()
        {
            EmailAddress first = EmailAddress.Create("adresica@gmail.com");
            EmailAddress second = EmailAddress.Create("adresicaa@gmail.com");

            var result = first.Equals(second);

            Assert.False(result);
        }

        [Fact]
        public void Inequality_Check_3()
        {
            String input = "adresica@gmail.com";
            EmailAddress address = EmailAddress.Create("adresicaa@gmail.com");

            var result = address != input;

            Assert.True(result);
        }

        [Fact]
        public void Inequality_Check_4()
        {
            EmailAddress first = EmailAddress.Create("adresica@gmail.com");
            EmailAddress second = EmailAddress.Create("adresicaa@gmail.com");

            var result = first != second;

            Assert.True(result);
        }
    }
}
