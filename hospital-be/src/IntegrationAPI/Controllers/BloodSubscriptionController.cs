using IntegrationAPI.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using IntegrationLibrary.BloodSubscriptions.Service;
using IntegrationLibrary.BloodSubscriptions;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodSubscriptionController : ControllerBase
    {
        private readonly IBloodSubscriptionService _service;

        public BloodSubscriptionController(IBloodSubscriptionService service)
        {
            _service = service;
        }
        [HttpGet]
        [ExternalAuthorizationFilter(ExpectedRoles = "Manager")]
        public ActionResult GetAll()
        {
            IEnumerable<BloodSubscription> bloodSubscriptions = _service.GetAll();
            return Ok(bloodSubscriptions);
        }

    }
}
