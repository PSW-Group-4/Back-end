using Confluent.Kafka;
using IntegrationAPI.Communications.ManagerRequests;
using IntegrationAPI.Communications.Producer;
using IntegrationAPI.Dtos.BloodRequests;
using IntegrationAPI.Dtos.BloodSupplies;
using IntegrationLibrary.BloodBanks.Service;
using IntegrationLibrary.ManagerBloodRequests.Model;
using IntegrationLibrary.ManagerBloodRequests.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerRequestController : ControllerBase
    {
        private readonly IManagerRequestService _service;
        private readonly IBloodBankService _bankService;
        private readonly IProducer _producer;

        public ManagerRequestController(IManagerRequestService service, IBloodBankService bankService, IProducer producer)
        {
            _service = service;
            _bankService = bankService;
            _producer = producer;
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
            string result = ManagerRequestSender.SendRequest(ManagerBloodRequestConverter.Convert(request));
            if (result.Equals("Completed"))
            {
                ReceivedBloodDto receivedBlooddto = new ReceivedBloodDto(request.Blood.BloodType.ToString(), request.Blood.Amount);
                _producer.Send(JsonSerializer.Serialize(receivedBlooddto), "hospital.blood.supply.topic");
            }
            return Ok(request);
        }
    }
}
