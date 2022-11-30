using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Exceptions;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestIntegrationApp.UnitTesting.BloodTypeVOTests
{
    public class BasicVOTests
    {
        [Fact]
        public void Checks_Equals_True()
        {
            BloodType a_neg = new BloodType(BloodGroup.A, RHFactor.NEGATIVE);
            BloodType a_neg2 = new BloodType(BloodGroup.A, RHFactor.NEGATIVE);

            var result = a_neg.Equals(a_neg2);
            result.ShouldBe(true);
        }
        [Fact]
        public void Checks_Equals_False()
        {
            BloodType a_neg = new BloodType(BloodGroup.A, RHFactor.NEGATIVE);
            BloodType b_pos = new BloodType(BloodGroup.B, RHFactor.POSITIVE);

            var result = a_neg.Equals(b_pos);
            result.ShouldBe(false);
        }
        [Fact]
        public void Checks_Type_Missmatch()
        {
            BloodType a_neg = new BloodType(BloodGroup.A, RHFactor.NEGATIVE);
            String b_pos = "b_pos";
            Assert.Throws<ArgumentException> (() => a_neg.Equals (b_pos));
        }
        [Fact]
        public void Checks_Equals_Override_True()
        {
            BloodType a_neg = new BloodType(BloodGroup.A, RHFactor.NEGATIVE);
            BloodType a_neg2 = new BloodType(BloodGroup.A, RHFactor.NEGATIVE);

            var result = a_neg == a_neg2;
            result.ShouldBe(true);
        }

        [Fact]
        public void Checks_NotEquals_Override_True()
        {
            BloodType a_neg = new BloodType(BloodGroup.A, RHFactor.NEGATIVE);
            BloodType b_pos = new BloodType(BloodGroup.B, RHFactor.POSITIVE);

            var result = a_neg != b_pos;
            result.ShouldBe(true);
        }
        [Fact]
        public void Checks_String_Cast_True()
        {
            string type = "A POSITIVE";
            BloodType typeFromString = BloodType.FromString(type);
            BloodType a_pos = new BloodType(BloodGroup.A, RHFactor.POSITIVE);
            var result = a_pos == typeFromString;
            result.ShouldBe(true);
        }
        [Fact]
        public void Checks_String_Cast_False()
        {
            string type = "A AAAA";
            BloodType typeFromString;
            Assert.Throws<EnumToStringCastException>(() => typeFromString = BloodType.FromString(type));
        }
        [Fact]
        public void Checks_Invalid_String_Exception()
        {
            string type = "AAAAA";
            BloodType typeFromString;
            Assert.Throws<IndexOutOfRangeException>(() => typeFromString = BloodType.FromString(type));
        }
    }
}
