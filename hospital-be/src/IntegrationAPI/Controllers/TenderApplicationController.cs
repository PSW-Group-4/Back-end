using IntegrationAPI.Dtos.TenderApplications;
using IntegrationLibrary.BloodBanks.Service;
using IntegrationLibrary.TenderApplications.Model;
using IntegrationLibrary.TenderApplications.Service;
using IntegrationLibrary.Tenders.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderApplicationController : ControllerBase
    {
        private readonly ITenderApplicationService _service;
        private readonly ITenderService _tenderService;
        private readonly IBloodBankService _bloodBankService;
        public TenderApplicationController(ITenderApplicationService service, ITenderService tenderService, IBloodBankService bloodBankService)
        {
            _tenderService = tenderService;
            _bloodBankService = bloodBankService;
            _service = service;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            IEnumerable<TenderApplication> tenderApplications = _service.GetAll();
            return Ok(tenderApplications);
        }
        [HttpPost]
        public ActionResult Apply(ApplyForTenderDto applicationDto) {
            TenderApplication application = new TenderApplication();
            application.ApplicationId = Guid.NewGuid();
            application.BloodBank = _bloodBankService.GetById(applicationDto.BloodBankId);
            application.Tender = _tenderService.GetById(applicationDto.TenderId);
            application.PriceInRSD = applicationDto.PriceInRSD;
            return Ok(_service.Apply(application));
        }
    }
}
