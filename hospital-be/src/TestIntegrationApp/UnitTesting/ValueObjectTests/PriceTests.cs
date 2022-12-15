using IntegrationLibrary.TenderApplications.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestIntegrationApp.UnitTesting.ValueObjectTests
{
    public class PriceTests
    {
        [Fact]
        public void Price_Is_Valid()
        {

            Price price = new Price(300, "RSD");

            bool result = Price.IsValid(price);

            Assert.True(result);
        }

        [Fact]
        public void Price_Is_Not_Valid_1()
        {
            Price price = new Price(-300, "RSD");
            bool result = Price.IsValid(price);
            Assert.False(result);
        }

        [Fact]
        public void Price_Is_Not_Valid_2()
        {
            Price price = new Price(300, "0sds");
            bool result = Price.IsValid(price);
            Assert.False(result);
        }
        [Fact]
        public void Equality_Check()
        {
            
            Price priceCreated = Price.Create(300,"RSD");
            Price price = new Price(300, "RSD");
            var result = priceCreated.Equals(price);

            Assert.True(result);
        }

        [Fact]
        public void Equality_Check_2()
        {
            Price first = Price.Create(300,"EUR");
            Price second = Price.Create(300,"EUR");

            var result = first.Equals(second);

            Assert.True(result);
        }
        [Fact]
        public void Equality_Check_3()
        {
            Price first = Price.Create(300, "EUR");
            Price second = Price.Create(300, "EUR");

            var result = first == second;

            Assert.True(result);
        }

        [Fact]
        public void Inequality_Check()
        {
            Price first = Price.Create(300, "EUR");
            Price second = Price.Create(500, "EUR");

            var result = first.Equals(second);

            Assert.False(result);
        }

        [Fact]
        public void Inquality_Check_2()
        {
            Price first = Price.Create(300, "RSD");
            Price second = Price.Create(300, "EUR");

            var result = first.Equals(second);

            Assert.False(result);
        }

        [Fact]
        public void Inequality_Check_3()
        {
            Price first = Price.Create(300, "RSD");
            Price second = Price.Create(300, "EUR");

            var result = first != second;

            Assert.True(result);
        }
    }
}
