using IntegrationLibrary.BloodReport.Service;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBankReportController : ControllerBase
    {
        private readonly IBbReportService _service;

        public BloodBankReportController(IBbReportService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult Create(string bloodBankId)
        {
            var retVal =  _service.Create(bloodBankId);
            return Ok(retVal);
        }
    }
}
