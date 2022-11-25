using System.Linq;
using System.Reflection;
using HospitalAPI.Controllers;
using Shouldly;
using Xunit;

namespace TestHospitalApp.UnitTesting.FeedbackTests
{
    public class FeedbackControllerTest
    {
        [Fact]
        public void checks_if_feedback_creating_is_authorized()
        {
            var controllers = typeof(FeedbackController).Assembly;
            var feedbackController = controllers.DefinedTypes.FirstOrDefault(t => t.FullName == "HospitalAPI.Controllers.FeedbackController");
            var createMethod = feedbackController.DeclaredMethods.FirstOrDefault(m => m.Name == "Create");

            var authorizeAttribute = createMethod.CustomAttributes.FirstOrDefault(a =>
                a.AttributeType == typeof(Microsoft.AspNetCore.Authorization.AuthorizeAttribute));
            
            authorizeAttribute.ShouldNotBeNull();
        }
    }
}