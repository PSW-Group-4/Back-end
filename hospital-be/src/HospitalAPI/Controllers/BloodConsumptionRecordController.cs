using System;
using AutoMapper;
using HospitalAPI.Dtos.BloodConsumptionRecord;
using HospitalLibrary.BloodConsumptionRecords.Model;
using HospitalLibrary.BloodConsumptionRecords.Service;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodConsumptionRecordController : ControllerBase
    {
        private readonly IBloodConsumptionRecordService _bloodConsumptionRecordService;
        private readonly IMapper _mapper;

        public BloodConsumptionRecordController(IBloodConsumptionRecordService bloodConsumptionRecordService,
            IMapper mapper)
        {
            _bloodConsumptionRecordService = bloodConsumptionRecordService;
            _mapper = mapper;
        }

        // GET: api/BloodConsumptionRecord
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_bloodConsumptionRecordService.GetAll());
        }

        // GET api/BloodConsumptionRecord/1
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] Guid id)
        {
            try
            {
                var bloodConsumptionRecord = _bloodConsumptionRecordService.GetById(id);
                return Ok(bloodConsumptionRecord);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // POST api/BloodConsumptionRecord
        [HttpPost]
        public ActionResult Create([FromBody] BloodConsumptionRecordRequestDto bloodConsumptionRecordRequestDto)
        {
            var bloodConsumptionRecord = _mapper.Map<BloodConsumptionRecord>(bloodConsumptionRecordRequestDto);
            return Ok(_bloodConsumptionRecordService.Create(bloodConsumptionRecord));
        }
    }
}