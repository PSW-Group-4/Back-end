using Microsoft.AspNetCore.Mvc;
using IntegrationLibrary.BloodBanks.Service;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBankController : ControllerBase
    {
        private readonly IBloodBankService _service;
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

    }
}
