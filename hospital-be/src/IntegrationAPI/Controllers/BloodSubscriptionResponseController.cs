using IntegrationAPI.Authorization;
using System.Collections.Generic;
using IntegrationLibrary.BloodSubscriptionResponses.Model;
using IntegrationLibrary.BloodSubscriptionResponses.Service;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodSubscriptionResponseController : ControllerBase
    {
        private readonly IBloodSubscriptionResponseService _service;

        public BloodSubscriptionResponseController(IBloodSubscriptionResponseService service)
        {
            _service = service;
        }

        [HttpGet]
        //[ExternalAuthorizationFilter(ExpectedRoles = "Manager")]
        public ActionResult GetAll()
        {
            IEnumerable<BloodSubscriptionResponse> responces = _service.GetAll();
            return Ok(responces);
        }
    }
}
