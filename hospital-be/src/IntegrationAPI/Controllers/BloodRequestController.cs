using AutoMapper;
using IntegrationLibrary.BloodRequests.Model;
using IntegrationLibrary.BloodRequests.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            IEnumerable<BloodRequest> bloodRequests = _service.GetAll();
            return Ok(bloodRequests);
        }

    }
}
