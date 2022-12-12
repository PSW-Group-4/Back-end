using System.Collections.Generic;
using IntegrationLibrary.BloodSubscriptions;
using IntegrationLibrary.Common;
using Shouldly;
using Xunit;

namespace TestIntegrationApp.UnitTesting.ValueObjectTests
{
    public class BloodSubscriptionTests
    {
        [Fact]
        public void Checks_addition()
        {
            BloodType type = new(BloodGroup.A, RhFactor.POSITIVE);
            Blood product = new(type, 150);
            BloodSubscription subscription = new();

            subscription.AddBloodType(product);

            Assert.True(subscription.Blood.Count == 1);
        }

        [Fact]
        public void Checks_addition_multiple()
        {
            BloodType type = new(BloodGroup.A, RhFactor.POSITIVE);
            BloodType type2 = new(BloodGroup.B, RhFactor.POSITIVE);
            Blood product = new(type, 150);
            Blood product2 = new(type2, 250);
            BloodSubscription subscription = new();
            List<Blood> types = new();
            types.Add(product);
            types.Add(product2);

            subscription.AddBloodType(types);

            (types.Count == subscription.Blood.Count).ShouldBe(true);
        }

        [Fact]
        public void Checks_removal()
        {
            BloodType type = new(BloodGroup.A, RhFactor.POSITIVE);
            BloodType type2 = new(BloodGroup.B, RhFactor.POSITIVE);
            BloodType type3 = new(BloodGroup.O, RhFactor.POSITIVE);
            Blood product = new(type, 150);
            Blood product2 = new(type2, 250);
            Blood product3 = new(type3, 69);
            BloodSubscription subscription = new();
            List<Blood> types = new();
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
            BloodType type = new(BloodGroup.A, RhFactor.POSITIVE);
            BloodType type2 = new(BloodGroup.B, RhFactor.POSITIVE);
            BloodType type3 = new(BloodGroup.O, RhFactor.POSITIVE);
            Blood product = new(type, 150);
            Blood product2 = new(type2, 250);
            Blood product3 = new(type3, 69);
            ;
            BloodSubscription subscription = new();
            List<Blood> types = new();
            types.Add(product);
            types.Add(product2);
            types.Add(product3);
            subscription.AddBloodType(types);
            List<Blood> forRemoval = new();
            forRemoval.Add(product);
            forRemoval.Add(product2);

            subscription.RemoveBloodType(forRemoval);

            types.Remove(product);
            types.Remove(product2);

            (types.Count == subscription.Blood.Count).ShouldBe(true);
        }
    }
}