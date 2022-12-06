using IntegrationAPI.Authorization;
using IntegrationLibrary.BloodSubscriptionReponces.Model;
using IntegrationLibrary.BloodSubscriptionReponces.Service;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodSubscriptionResponceController : ControllerBase
    {
        private readonly IBloodSubscriptionResponceService _service;

        public BloodSubscriptionResponceController(IBloodSubscriptionResponceService service)
        {
            _service = service;
        }

        [HttpGet]
        //[ExternalAuthorizationFilter(ExpectedRoles = "Manager")]
        public ActionResult GetAll()
        {
            IEnumerable<BloodSubscriptionRepsponce> responces = _service.GetAll();
            return Ok(responces);
        }
    }
}
