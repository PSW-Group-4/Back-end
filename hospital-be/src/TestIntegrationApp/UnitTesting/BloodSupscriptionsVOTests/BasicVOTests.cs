using IntegrationLibrary.BloodSubscriptions;
using IntegrationLibrary.Common;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestIntegrationApp.UnitTesting.BloodSupscriptionsVOTests
{
    public class BasicVOTests
    {
        [Fact]
        public void Checks_addition()
        {
            BloodType type = new BloodType(BloodGroup.A, RHFactor.POSITIVE);
            BloodSubscription subscription = new BloodSubscription("TestBB");

            subscription.addBloodType(type);

            List<BloodType> types = new List<BloodType>();
            types.Add(type);
            types.Equals(subscription.BloodTypes).ShouldBe(true);

        }
        [Fact]
        public void Checks_addition_multiple()
        {
            BloodType type = new BloodType(BloodGroup.A, RHFactor.POSITIVE);
            BloodType type2 = new BloodType(BloodGroup.B, RHFactor.POSITIVE);
            BloodSubscription subscription = new BloodSubscription("TestBB");
            List<BloodType> types = new List<BloodType>();
            types.Add(type);
            types.Add(type2);

            subscription.addBloodType(types);

            
            types.Equals(subscription.BloodTypes).ShouldBe(true);

        }
        [Fact]
        public void Checks_removal()
        {
            BloodType type = new BloodType(BloodGroup.A, RHFactor.POSITIVE);
            BloodType type2 = new BloodType(BloodGroup.B, RHFactor.POSITIVE);
            BloodType type3 = new BloodType(BloodGroup.O, RHFactor.POSITIVE);
            BloodSubscription subscription = new BloodSubscription("TestBB");
            List<BloodType> types = new List<BloodType>();
            types.Add(type);
            types.Add(type2);
            types.Add(type3);
            subscription.addBloodType(types);

            subscription.removeBloodType(type);

            types.Remove(type);
            types.Equals(subscription.BloodTypes).ShouldBe(true);

        }
        [Fact]
        public void Checks_removal_multiple()
        {
            BloodType type = new BloodType(BloodGroup.A, RHFactor.POSITIVE);
            BloodType type2 = new BloodType(BloodGroup.B, RHFactor.POSITIVE);
            BloodType type3 = new BloodType(BloodGroup.O, RHFactor.POSITIVE);
            BloodSubscription subscription = new BloodSubscription("TestBB");
            List<BloodType> types = new List<BloodType>();
            types.Add(type);
            types.Add(type2);
            types.Add(type3);
            subscription.addBloodType(types);
            List<BloodType> forRemoval = new List<BloodType>();
            forRemoval.Add(type);
            forRemoval.Add(type2);


            subscription.removeBloodType(forRemoval);

            types.Remove(type);
            types.Remove(type2);
            types.Equals(subscription.BloodTypes).ShouldBe(true);

        }
    }
}
