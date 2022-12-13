using IntegrationAPI.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using IntegrationLibrary.BloodSubscriptions.Service;
using IntegrationLibrary.BloodSubscriptions;
using IntegrationAPI.Dtos.BloodSubscription;

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
        [HttpPost]
        public ActionResult Create(BloodSubscriptionCreatingDto dto)
        {
            BloodSubscription subscription = SubscriptionConverter.Convert(dto);
            _service.Create(subscription);
            return Ok(subscription);
        }

    }
}
