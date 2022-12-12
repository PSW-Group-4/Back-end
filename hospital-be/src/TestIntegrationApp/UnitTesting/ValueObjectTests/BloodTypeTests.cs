using System;
using IntegrationLibrary.Common;
using IntegrationLibrary.Exceptions;
using Shouldly;
using Xunit;

namespace TestIntegrationApp.UnitTesting.ValueObjectTests
{
    public class BloodTypeTests
    {
        [Fact]
        public void Checks_Equals_True()
        {
            BloodType a_neg = new(BloodGroup.A, RhFactor.NEGATIVE);
            BloodType a_neg2 = new(BloodGroup.A, RhFactor.NEGATIVE);

            var result = a_neg.Equals(a_neg2);
            result.ShouldBe(true);
        }

        [Fact]
        public void Checks_Equals_False()
        {
            BloodType a_neg = new(BloodGroup.A, RhFactor.NEGATIVE);
            BloodType b_pos = new(BloodGroup.B, RhFactor.POSITIVE);

            var result = a_neg.Equals(b_pos);
            result.ShouldBe(false);
        }

        [Fact]
        public void Checks_Type_Missmatch()
        {
            BloodType a_neg = new(BloodGroup.A, RhFactor.NEGATIVE);
            var b_pos = "b_pos";
            Assert.Throws<ArgumentException>(() => a_neg.Equals(b_pos));
        }

        [Fact]
        public void Checks_Equals_Override_True()
        {
            BloodType a_neg = new(BloodGroup.A, RhFactor.NEGATIVE);
            BloodType a_neg2 = new(BloodGroup.A, RhFactor.NEGATIVE);

            var result = a_neg == a_neg2;
            result.ShouldBe(true);
        }

        [Fact]
        public void Checks_NotEquals_Override_True()
        {
            BloodType a_neg = new(BloodGroup.A, RhFactor.NEGATIVE);
            BloodType b_pos = new(BloodGroup.B, RhFactor.POSITIVE);

            var result = a_neg != b_pos;
            result.ShouldBe(true);
        }

        [Fact]
        public void Checks_String_Cast_True()
        {
            var type = "A POSITIVE";
            BloodType typeFromString = BloodType.FromString(type);
            BloodType a_pos = new(BloodGroup.A, RhFactor.POSITIVE);
            var result = a_pos == typeFromString;
            result.ShouldBe(true);
        }

        [Fact]
        public void Checks_String_Cast_True_2()
        {
            var type = "AB-";
            BloodType typeFromString = BloodType.FromString(type);
            BloodType ab_neg = new(BloodGroup.AB, RhFactor.NEGATIVE);
            var result = ab_neg == typeFromString;
            result.ShouldBe(true);
        }

        [Fact]
        public void Checks_String_Cast_False()
        {
            var type = "A AAAA";
            BloodType typeFromString;
            Assert.Throws<EnumToStringCastException>(() => typeFromString = BloodType.FromString(type));
        }

        [Fact]
        public void Checks_Invalid_String_Exception()
        {
            var type = "AAAAA";
            BloodType typeFromString;
            Assert.Throws<EnumToStringCastException>(() => typeFromString = BloodType.FromString(type));
        }
    }
}