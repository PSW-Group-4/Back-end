using System.Collections.Generic;
using IntegrationAPI.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Moq;
using Xunit;
using ActionDescriptor = Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor;
using ModelStateDictionary = Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;

namespace TestIntegrationApp.UnitTesting.ExternalAuthorizationFilterTests
{
    public class ExternalAuthorizationFilterTest
    {
        [Fact]
        public void Request_without_jwt_fails_to_authorize()
        {
            var filter = new ExternalAuthorizationFilter{ExpectedRoles = "Manager"};

            var actionContext = new ActionContext(
                            Mock.Of<HttpContext>(),
                            Mock.Of<RouteData>(),
                            Mock.Of<ActionDescriptor>(),
                            Mock.Of<ModelStateDictionary>()
                        );
            
            var actionExecutingContext = new ActionExecutingContext(
                            actionContext,
                            new List<IFilterMetadata>(),
                            new Dictionary<string, object>(),
                            Mock.Of<Controller>()
                        );
            
            filter.OnActionExecuting(actionExecutingContext);
            Assert.IsType<UnauthorizedResult>(actionExecutingContext.Result);
        }
    }
}