using IntegrationLibrary.BloodBanks.Model;
using System;
using Xunit;

namespace TestIntegrationApp.UnitTesting.ValueObjectTests
{
    public class ApiKeyTest
    {
        [Fact]
        public void ApiKey_Is_Valid()
        {
            String input = "PtPVoYRT7SkCXZGiHqTjPhAwikf228hjdQJmmdfqMTRZt8G326vZVZPQNRhR03vUDz8zCGsSEF6Ccwqn1o7HRs7fKg8Vn4d0IS1uBsgS5i74Kf3r18SNYipgFer1KtBB";
            
            ApiKey a = new ApiKey(input);
            bool result = a.IsValid();

            Assert.True(result);
        }

        [Fact]
        public void ApiKey_Is_Valid1()
        {
            String input = "Da li je ovo api key?";
            bool result = true;
            try
            {
                ApiKey a = new ApiKey(input);
            }
            catch
            {
                result = false;
            }

            Assert.False(result);
        }

        [Fact]
        public void Equality_Check()
        {
            ApiKey a = new ApiKey("PtPVoYRT7SkCXZGiHqTjPhAwikf228hjdQJmmdfqMTRZt8G326vZVZPQNRhR03vUDz8zCGsSEF6Ccwqn1o7HRs7fKg8Vn4d0IS1uBsgS5i74Kf3r18SNYipgFer1KtBB");
            ApiKey a1 = new ApiKey("PtPVoYRT7SkCXZGiHqTjPhAwikf228hjdQJmmdfqMTRZt8G326vZVZPQNRhR03vUDz8zCGsSEF6Ccwqn1o7HRs7fKg8Vn4d0IS1uBsgS5i74Kf3r18SNYipgFer1KtBB");
            var result = a.Equals(a1);

            Assert.True(result);
        }

        [Fact]
        public void Equality_Check1()
        {
            ApiKey a = new ApiKey("5tPVoYRT7SkCXZGiHqTjPhAwikf228hjdQJmmdfqMTRZt8G326vZVZPQNRhR03vUDz8zCGsSEF6Ccwqn1o7HRs7fKg8Vn4d0IS1uBsgS5i74Kf3r18SNYipgFer1KtBB");
            ApiKey a1 = new ApiKey("PtPVoYRT7SkCXZGiHqTjPhAwikf228hjdQJmmdfqMTRZt8G326vZVZPQNRhR03vUDz8zCGsSEF6Ccwqn1o7HRs7fKg8Vn4d0IS1uBsgS5i74Kf3r18SNYipgFer1KtBB");
            var result = a.Equals(a1);

            Assert.False(result);
        }

        [Fact]
        public void Equality_Check2()
        {
            ApiKey a = new ApiKey("5tPVoYRT7SkCXZGiHqTjPhAwikf228hjdQJmmdfqMTRZt8G326vZVZPQNRhR03vUDz8zCGsSEF6Ccwqn1o7HRs7fKg8Vn4d0IS1uBsgS5i74Kf3r18SNYipgFer1KtBB");
            String input = "PtPVoYRT7SkCXZGiHqTjPhAwikf228hjdQJmmdfqMTRZt8G326vZVZPQNRhR03vUDz8zCGsSEF6Ccwqn1o7HRs7fKg8Vn4d0IS1uBsgS5i74Kf3r18SNYipgFer1KtBB";
            var result = a.Equals(input);

            Assert.False(result);
        }
    }
}
