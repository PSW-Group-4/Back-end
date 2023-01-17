using IntegrationAPI.Dtos.TenderApplications;
using IntegrationLibrary.BloodBanks.Service;
using IntegrationLibrary.TenderApplications.Model;
using IntegrationLibrary.TenderApplications.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.Service;
using IntegrationAPI.Authorization;
using Microsoft.AspNetCore.Authorization;
using JwtService = IntegrationLibrary.Utilities.JwtService;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Tendering.DomainEvents.Subtypes;
using IntegrationLibrary.Tendering.Model;
using IntegrationLibrary.Tendering.Service;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderApplicationController : ControllerBase
    {
        private readonly ITenderApplicationService _service;
        private readonly ITenderService _tenderService;
        private readonly IBloodBankService _bloodBankService;

        public TenderApplicationController(ITenderApplicationService service, ITenderService tenderService,
            IBloodBankService bloodBankService)
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
        [Authorize(Roles = "BloodBank")]
        public ActionResult Submit(ApplyForTenderDto tenderApplication)
        {    
            /*BloodBank bank =
                _bloodBankService.GetByEmail(tenderApplication.BloodBank);*/
            BloodBank bank = _bloodBankService.GetByEmail(JwtService.GetEmailFromToken(tenderApplication.BloodBank));
            Tender tender = _tenderService.GetById(tenderApplication.TenderId);
            Price price = new(tenderApplication.PriceInRSD, "RSD");
            AppliedToTenderEvent appliedToTenderEvent = new(bank, tender, price);
            _service.Submit(appliedToTenderEvent);
            return Ok();
        }

        [Route("tender/{tenderId}"), HttpGet]
        public ActionResult GetByTender(string tenderId)
        {
            return Ok(_service.GetByTender(Guid.Parse(tenderId)));
        }

        [Route("notify/{applicationId}"), HttpPost]
        [ExternalAuthorizationFilter(ExpectedRoles = "Manager")]
        public ActionResult NotifyParticipants(string applicationId)
        {
            TenderApplication application = _service.FindById(Guid.Parse(applicationId));
            return Ok(_service.NotifyParticipants(application));
        }
    }
}