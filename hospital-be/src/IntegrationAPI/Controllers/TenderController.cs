using IntegrationAPI.Dtos.Tenders;
using IntegrationLibrary.Tenders.Service;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : Controller
    {
        private readonly ITenderService tenderService;

        public TenderController(ITenderService tenderService)
        {
            this.tenderService = tenderService;
        }

        [HttpPost]
        public ActionResult Create(TenderDto dto)
        {
            return Ok();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok();
        }
    }
}
