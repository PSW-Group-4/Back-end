using Microsoft.AspNetCore.Mvc;
using IntegrationLibrary.BloodBanks.Service;
using AutoMapper;
using System.Collections.Generic;
using IntegrationLibrary.BloodBanks.Model;
using System;
using IntegrationAPI.Authorization;
using IntegrationAPI.Dtos.BloodBank;
using IntegrationAPI.Communications.Mail;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBankController : ControllerBase
    {
        private readonly IBloodBankService _service;
        private readonly IMapper _mapper;
        private readonly IMailSender _mailSender;

        public BloodBankController(IBloodBankService service, IMapper mapper, IMailSender mailSender)
        {
            _service = service;
            _mapper = mapper;
            _mailSender = mailSender;
        }

        [HttpGet]
        [ExternalAuthorizationFilter(ExpectedRoles = "Manager")]
        public ActionResult GetAll()
        {
            IEnumerable<BloodBank> bloodBanks = _service.GetAll();
            return Ok(bloodBanks);
        }
        [HttpPost]
        public ActionResult Create(BloodBankRegisterDto bloodBankDto)
        {
            BloodBank bloodBank = _mapper.Map<BloodBank>(bloodBankDto);
            _service.Create(bloodBank);
            _mailSender.sendEmail(_mailSender.createTxtEmail(bloodBank.Name, bloodBank.EmailAddress, IntegrationLibrary.Settings.EmailingResources.EmailSubjectBB, _mailSender.CreateEmailText(bloodBank)));
            return Ok(bloodBank);
        }
        [HttpGet("{ApiKey}")]
        public ActionResult GetByApiKey(string ApiKey)
        {
            BloodBank bloodBank = _service.GetByApiKey(ApiKey);
            return Ok(bloodBank);
        }
        [HttpPost ("{id}")]
        public ActionResult Update(String Id, BloodBankEditDto bloodBankDto)
        {
            BloodBank bloodBank = _mapper.Map<BloodBank>(bloodBankDto);
            _service.Update(bloodBank);
            return Ok(bloodBank);
        }
    }
}
