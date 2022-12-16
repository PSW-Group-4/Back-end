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
using HospitalLibrary.Core.Service;
using IntegrationAPI.Authorization;
using Microsoft.AspNetCore.Authorization;
using JwtService = IntegrationLibrary.Utilities.JwtService;

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
        public ActionResult Apply(ApplyForTenderDto tenderApplication)
        {
            TenderApplication application = new TenderApplication();
            application.ApplicationId = Guid.NewGuid();
            application.BloodBank =
                _bloodBankService.GetByEmail(JwtService.GetEmailFromToken(tenderApplication.BloodBank));
            application.Tender = _tenderService.GetById(tenderApplication.TenderId);
            application.PriceInRSD = tenderApplication.PriceInRSD;
            return Ok(_service.Apply(application));
        }

        [Route("tender"), HttpPost]
        public ActionResult GetByTender(string tenderId)
        {
            return Ok(_service.GetByTender(Guid.Parse(tenderId)));
        }

        [Route("accept"), HttpPost]
        [ExternalAuthorizationFilter(ExpectedRoles = "Manager")]
        public ActionResult AcceptOffer(string applicationId)
        {
            TenderApplication application = _service.FindById(Guid.Parse(applicationId));
            return Ok(_service.AcceptOffer(application));
        }
    }
}