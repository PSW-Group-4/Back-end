using IntegrationAPI.Communications.ManagerRequests;
using IntegrationAPI.Dtos.BloodRequests;
using IntegrationLibrary.BloodBanks.Service;
using IntegrationLibrary.ManagerBloodRequests.Model;
using IntegrationLibrary.ManagerBloodRequests.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerRequestController : ControllerBase
    {
        private readonly IManagerRequestService _service;
        private readonly IBloodBankService _bankService;

        public ManagerRequestController(IManagerRequestService service, IBloodBankService bankService)
        {
            _service = service;
            _bankService = bankService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            IEnumerable<ManagerRequest> requests = _service.GetAll();
            return Ok(requests);
        }
        [HttpPost]
        public ActionResult Create(ManagerBloodRequestCreateDto dto)
        {
            ManagerRequest request = new ManagerRequest();
            request.Blood = new IntegrationLibrary.Common.Blood(IntegrationLibrary.Common.BloodType.FromString(dto.BloodType),dto.Amount);
            request.BloodBank = _bankService.GetById(new Guid(dto.BloodBankId));
            if(request.BloodBank == null)
            {
                return BadRequest();
            }
            request.ManagerId = dto.ManagerId;
            _service.Create(request);
            ManagerRequestSender.SendRequest(ManagerBloodRequestConverter.Convert(request));
            return Ok(request);
        }
    }
}
