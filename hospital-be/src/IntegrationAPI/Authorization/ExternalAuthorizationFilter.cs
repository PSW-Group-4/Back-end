using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IntegrationAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ActionExecutingContext = Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext;
using ActionFilterAttribute = Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute;

namespace IntegrationAPI.Authorization
{
    public class ExternalAuthorizationFilter : ActionFilterAttribute
    {
        public string ExpectedRoles { get; set; }
        private readonly HttpClient _httpClient;
        private readonly string _authorizationEndpoint;

        //Can't use dependency injection inside filters...
        public ExternalAuthorizationFilter()
        {
            _httpClient = new HttpClient();
            _authorizationEndpoint = "http://localhost:16177/api/User/AuthorizeIntegrationApi";
        }

         public override  void  OnActionExecuting(ActionExecutingContext context)
        {
            if (ExpectedRoles == null) return;
            
            string jwt = context.HttpContext.Request.Headers["Authorization"];
            if (jwt == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }
            
            var response =  SendAuthorizationRequest(jwt);
            response.Wait();
            
            if (response.Result.StatusCode == HttpStatusCode.Unauthorized)
            {
                context.Result = new UnauthorizedResult();
            }
        }

         private async Task<HttpResponseMessage> SendAuthorizationRequest(string jwt)
         {
             var dto = new IntegrationAuthorizationDto { ExpectedRoles = ExpectedRoles };
             var httpRequestMessage = new HttpRequestMessage
                             {
                                 Method = HttpMethod.Post,
                                 RequestUri = new Uri(_authorizationEndpoint),
                                 Headers = { 
                                     { HttpRequestHeader.Authorization.ToString(), jwt },
                                     { HttpRequestHeader.ContentType.ToString(), "application/json" }
                                 },
                                 Content = new StringContent(JsonConvert.SerializeObject(dto), System.Text.Encoding.UTF8, "application/json")
                             };
             var response = await _httpClient.SendAsync(httpRequestMessage);
             return response;
         }
    }
}