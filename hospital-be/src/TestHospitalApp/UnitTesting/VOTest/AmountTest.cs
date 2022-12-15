using System;
using HospitalLibrary.BloodConsumptionRecords.Model;
using HospitalLibrary.Exceptions;
using Shouldly;
using Xunit;

namespace TestHospitalApp.UnitTesting.VOTest
{
    public class AmountTest
    {
        [Fact]
        public void Valid_positive_amount()
        {
            double value = 150.75;

            Amount amount = new Amount(value);

            amount.ShouldNotBeNull();
        }

        [Fact]
        public void Invalid_zero_amount()
        {
            double value = 0;

            Should.Throw<ValueObjectValidationFailedException>(() =>
            {
                Amount amount = new Amount(value);
            });
        }

        [Fact]
        public void Invalid_negative_amount()
        {
            double value = -50;

            Should.Throw<ValueObjectValidationFailedException>(() =>
            {
                Amount amount = new Amount(value);
            });
        }

        [Fact]
        public void Amounts_are_equal()
        {
            Amount amount1 = new Amount(200);
            Amount amount2 = new Amount(200.00);

            var result = amount1.Equals(amount2);

            result.ShouldBeTrue();
        }

        [Fact]
        public void Ammounts_are_not_equal()
        {
            Amount amount1 = new Amount(300);
            Amount amount2 = new Amount(200.00);

            var result = amount1.Equals(amount2);

            result.ShouldBeFalse();
        }
    }
}