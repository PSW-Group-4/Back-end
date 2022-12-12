using IntegrationLibrary.ManagerBloodRequests.Model;
using IntegrationLibrary.ManagerBloodRequests.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerRequestController : ControllerBase
    {
        private readonly IManagerRequestService _service;

        public ManagerRequestController(IManagerRequestService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            IEnumerable<ManagerRequest> requests = _service.GetAll();
            return Ok(requests);
        }
    }
}
