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

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodRequestController : ControllerBase
    {
        private readonly IBloodRequestService _service;
        private readonly IMapper _mapper;
        private readonly IProducer<BloodRequest> bloodRequestProducer;

        public BloodRequestController(IBloodRequestService service, IMapper mapper)
        {

            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            IEnumerable<BloodRequest> bloodRequests = _service.GetAll();
            return Ok(bloodRequests);
        }
        [Route("unapproved"), HttpGet]
        public ActionResult GetUnapproved()
        {
            IEnumerable<BloodRequest> bloodRequests = _service.GetUnapproved();
            return Ok(bloodRequests);
        }
        [Route("update"), HttpPost]
        public ActionResult Update(BloodRequestEditDto bloodRequestDto)
        {
            var bloodRequest = _mapper.Map<BloodRequest>(bloodRequestDto);
            if(bloodRequestDto.IsApproved)
            {
                BloodRequestMessageDto message = new()
                {
                    BloodType = bloodRequest.BloodType,
                    RHFactor = bloodRequest.RHFactor,
                    BloodAmountInMilliliters = bloodRequest.BloodAmountInMilliliters,
                    SendOnDate = bloodRequest.SendOnDate
                };
                bloodRequestProducer.Send(JsonSerializer.Serialize(message));
            }
            return Ok(_service.Update(bloodRequest));
        }

        [HttpPost]
        public ActionResult Create([FromBody] BloodRequestsCreateDto bloodRequestDto)
        {
            var bloodRequest = _mapper.Map<BloodRequest>(bloodRequestDto);
            return Ok(_service.Create(bloodRequest));
        }
    }
}
