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
            BloodProduct product = new BloodProduct(type,150);
            BloodSubscription subscription = new BloodSubscription("TestBB");

            subscription.AddBloodType(product);

            List<BloodProduct> types = new List<BloodProduct>();
            types.Add(product);
            types.Equals(subscription.BloodProducts).ShouldBe(true);

        }
        [Fact]
        public void Checks_addition_multiple()
        {
            BloodType type = new BloodType(BloodGroup.A, RHFactor.POSITIVE);
            BloodType type2 = new BloodType(BloodGroup.B, RHFactor.POSITIVE);
            BloodProduct product = new BloodProduct(type, 150);
            BloodProduct product2 = new BloodProduct(type2, 250);
            BloodSubscription subscription = new BloodSubscription("TestBB");
            List<BloodProduct> types = new List<BloodProduct>();
            types.Add(product);
            types.Add(product2);

            subscription.AddBloodType(types);

            
            types.Equals(subscription.BloodProducts).ShouldBe(true);

        }
        [Fact]
        public void Checks_removal()
        {
            BloodType type = new BloodType(BloodGroup.A, RHFactor.POSITIVE);
            BloodType type2 = new BloodType(BloodGroup.B, RHFactor.POSITIVE);
            BloodType type3 = new BloodType(BloodGroup.O, RHFactor.POSITIVE);
            BloodProduct product = new BloodProduct(type, 150);
            BloodProduct product2 = new BloodProduct(type2, 250);
            BloodProduct product3 = new BloodProduct(type3, 69);
            BloodSubscription subscription = new BloodSubscription("TestBB");
            List<BloodProduct> types = new List<BloodProduct>();
            types.Add(product);
            types.Add(product2);
            types.Add(product3);
            subscription.AddBloodType(types);

            subscription.RemoveBloodType(product);

            types.Remove(product);
            types.Equals(subscription.BloodProducts).ShouldBe(true);

        }
        [Fact]
        public void Checks_removal_multiple()
        {
            BloodType type = new BloodType(BloodGroup.A, RHFactor.POSITIVE);
            BloodType type2 = new BloodType(BloodGroup.B, RHFactor.POSITIVE);
            BloodType type3 = new BloodType(BloodGroup.O, RHFactor.POSITIVE);
            BloodProduct product = new BloodProduct(type, 150);
            BloodProduct product2 = new BloodProduct(type2, 250);
            BloodProduct product3 = new BloodProduct(type3, 69); ;
            BloodSubscription subscription = new BloodSubscription("TestBB");
            List<BloodProduct> types = new List<BloodProduct>();
            types.Add(product);
            types.Add(product2);
            types.Add(product3);
            subscription.AddBloodType(types);
            List<BloodProduct> forRemoval = new List<BloodProduct>();
            forRemoval.Add(product);
            forRemoval.Add(product2);


            subscription.RemoveBloodType(forRemoval);

            types.Remove(product);
            types.Remove(product2);
            types.Equals(subscription.BloodProducts).ShouldBe(true);

        }
    }
}
