using AutoMapper;
using IntegrationLibrary.BloodRequests.Model;
using IntegrationLibrary.BloodRequests.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationAPI.Dtos.BloodRequests;
using IntegrationAPI.Communications.Producer;
using System.Text.Json;
using IntegrationAPI.Authorization;
using IntegrationLibrary.Common;
using IntegrationAPI.Dtos.BloodTypes;
using IntegrationAPI.Dtos.BloodProducts;
using IntegrationLibrary.BloodBanks.Service;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodRequestController : ControllerBase
    {
        private readonly IBloodRequestService _service;
        private readonly IMapper _mapper;
        private readonly IProducer bloodRequestProducer;
        private readonly IBloodBankService bloodBankService;

        public BloodRequestController(IBloodRequestService service, IBloodBankService bloodBankService, IProducer bloodRequestProducer)
        {
            _service = service;
            this.bloodBankService = bloodBankService;
            this.bloodRequestProducer = bloodRequestProducer;
        }

        [HttpGet]
        [ExternalAuthorizationFilter(ExpectedRoles = "Manager, Doctor")]
        public ActionResult GetAll()
        {
            IEnumerable<BloodRequest> bloodRequests = _service.GetAll();
            return Ok(bloodRequests);
        }

        [Route("unapproved"), HttpGet]
        [ExternalAuthorizationFilter(ExpectedRoles = "Manager")]
        public ActionResult GetUnapproved()
        {
            IEnumerable<BloodRequest> bloodRequests = _service.GetUnapproved();
            return Ok(bloodRequests);
        }

        [Route("manage"), HttpPost]
        //[ExternalAuthorizationFilter(ExpectedRoles = "Manager")]
        public ActionResult Manage(BloodRequestEditDto bloodRequestDto) {
            BloodRequest bloodRequest = _service.GetById(bloodRequestDto.Id);
            bloodRequest.IsApproved = bloodRequestDto.IsApproved;
            bloodRequest.ManagerId = bloodRequestDto.ManagerId;
            if(bloodRequestDto.IsApproved)
            {
                BloodRequestMessageDto messageDto = new(bloodRequest.Id, bloodRequest.Blood.BloodType.ToString(), bloodRequest.Blood.Amount, bloodRequest.SendOnDate, bloodRequest.IsUrgent);
                bloodRequestProducer.Send(JsonSerializer.Serialize(messageDto), "blood.requests.topic");
            } else
            {
                bloodRequest.RejectionComment = bloodRequestDto.RejectionComment;
            }
            return Ok(_service.Update(bloodRequest));
        }

        [HttpPost]
        [ExternalAuthorizationFilter(ExpectedRoles = "Doctor")]
        public ActionResult Create([FromBody] BloodRequestsCreateDto bloodRequestDto)
        {
            BloodRequest bloodRequest = new()
            {
                Blood = BloodConverter.Convert(bloodRequestDto.BloodDto),
                DoctorId = bloodRequestDto.DoctorId,
                Reasons = bloodRequestDto.Reasons,
                IsUrgent = bloodRequestDto.IsUrgent,
                SendOnDate = bloodRequestDto.SendOnDate
            };
            return Ok(_service.Create(bloodRequest));
        }
    }
}
