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
            BloodType type = new BloodType(BloodGroup.A, RhFactor.POSITIVE);
            Blood product = new Blood(type,150);
            BloodSubscription subscription = new BloodSubscription("TestBB",13);

            subscription.AddBloodType(product);

            Assert.True(subscription.Blood.Count == 1);

        }
        [Fact]
        public void Checks_addition_multiple()
        {
            BloodType type = new BloodType(BloodGroup.A, RhFactor.POSITIVE);
            BloodType type2 = new BloodType(BloodGroup.B, RhFactor.POSITIVE);
            Blood product = new Blood(type, 150);
            Blood product2 = new Blood(type2, 250);
            BloodSubscription subscription = new BloodSubscription("TestBB",13);
            List<Blood> types = new List<Blood>();
            types.Add(product);
            types.Add(product2);

            subscription.AddBloodType(types);
            
            (types.Count == subscription.Blood.Count).ShouldBe(true);

        }
        [Fact]
        public void Checks_removal()
        {
            BloodType type = new BloodType(BloodGroup.A, RhFactor.POSITIVE);
            BloodType type2 = new BloodType(BloodGroup.B, RhFactor.POSITIVE);
            BloodType type3 = new BloodType(BloodGroup.O, RhFactor.POSITIVE);
            Blood product = new Blood(type, 150);
            Blood product2 = new Blood(type2, 250);
            Blood product3 = new Blood(type3, 69);
            BloodSubscription subscription = new BloodSubscription("TestBB",13);
            List<Blood> types = new List<Blood>();
            types.Add(product);
            types.Add(product2);
            types.Add(product3);
            subscription.AddBloodType(types);

            subscription.RemoveBloodType(product);

            types.Remove(product);
            (types.Count == subscription.Blood.Count).ShouldBe(true);

        }
        [Fact]
        public void Checks_removal_multiple()
        {
            BloodType type = new BloodType(BloodGroup.A, RhFactor.POSITIVE);
            BloodType type2 = new BloodType(BloodGroup.B, RhFactor.POSITIVE);
            BloodType type3 = new BloodType(BloodGroup.O, RhFactor.POSITIVE);
            Blood product = new Blood(type, 150);
            Blood product2 = new Blood(type2, 250);
            Blood product3 = new Blood(type3, 69); ;
            BloodSubscription subscription = new BloodSubscription("TestBB",13);
            List<Blood> types = new List<Blood>();
            types.Add(product);
            types.Add(product2);
            types.Add(product3);
            subscription.AddBloodType(types);
            List<Blood> forRemoval = new List<Blood>();
            forRemoval.Add(product);
            forRemoval.Add(product2);

            subscription.RemoveBloodType(forRemoval);

            types.Remove(product);
            types.Remove(product2);
            
            (types.Count == subscription.Blood.Count).ShouldBe(true);

        }
    }
}
