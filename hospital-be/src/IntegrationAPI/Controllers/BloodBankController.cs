using Microsoft.AspNetCore.Mvc;
using IntegrationLibrary.BloodBanks.Service;
using AutoMapper;
using System.Collections.Generic;
using IntegrationLibrary.BloodBanks.Model;
using Microsoft.AspNetCore.Http;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBankController : ControllerBase
    {
        private readonly IBloodBankService _service;
        private readonly IMapper _mapper;

        public BloodBankController(IBloodBankService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            IEnumerable<BloodBank> bloodBanks = _service.GetAll();
            return Ok(bloodBanks);
        }
        [HttpPost]
        public ActionResult Create(BloodBankRegisterDto bloodBankDto)
        {
            var bloodBank = _mapper.Map<BloodBank>(bloodBankDto);
            _service.Create(bloodBank);
            return Ok(bloodBank);
        }
    }
}
