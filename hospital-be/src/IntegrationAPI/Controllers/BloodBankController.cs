using Microsoft.AspNetCore.Mvc;
using IntegrationLibrary.BloodBanks.Service;
using AutoMapper;
using System.Collections.Generic;
using IntegrationLibrary.BloodBanks.Model;

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
            IEnumerable<BloodBankDto> bloodBanksDto = _mapper.Map<IEnumerable<BloodBank>, IEnumerable<BloodBankDto>>(bloodBanks);
            return Ok(bloodBanksDto);
        }
        [HttpPost]
        public ActionResult Create( BloodBankDto bloodBankDto)
        {
            var bloodBank = _mapper.Map<BloodBank>(bloodBankDto);
            _service.Create(bloodBank);
            return CreatedAtAction("GetById", new { id = bloodBank.Id }, bloodBank);
        }
    }
}
