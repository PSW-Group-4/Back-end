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
using System.Net;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodRequestController : ControllerBase
    {
        private readonly IBloodRequestService _service;
        private readonly IMapper _mapper;

        public BloodRequestController(IBloodRequestService service, IMapper mapper) 
        {

             _service = service;
             _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            IEnumerable<BloodRequestDto> bloodRequests = _service.GetAll();
            return Ok(bloodRequests);
        }

        [HttpPost]
        public ActionResult Create([FromBody] BloodRequestsCreateDto bloodRequestsDto)
        {
            var bloodRequest = _mapper.Map<BloodRequestDto>(bloodRequestsDto);

            bloodRequest.doctorId = "5c036fba-1118-4f4b-b153-90d75e60625e";

            _service.Create(bloodRequest);
            return CreatedAtAction("GetById", new { id = bloodRequest.requestId }, bloodRequest);
        }
    }
}
