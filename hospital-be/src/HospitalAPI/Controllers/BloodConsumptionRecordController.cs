using HospitalLibrary.BloodConsumptionRecords.Model;
using HospitalLibrary.BloodConsumptionRecords.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using HospitalLibrary;
using System.Collections.Generic;
using HospitalAPI.Dtos.BloodConsumptionRecord;
using HospitalLibrary.Exceptions;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodConsumptionRecordController : ControllerBase
    {
        private readonly IBloodConsumptionRecordService _bloodConsumptionRecordService;
        private readonly IMapper _mapper;

        public BloodConsumptionRecordController(IBloodConsumptionRecordService bloodConsumptionRecordService, IMapper mapper)
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
            _bloodConsumptionRecordService.Create(bloodConsumptionRecord);
            return CreatedAtAction("GetById", new { id = bloodConsumptionRecord.Id }, bloodConsumptionRecord);
        }

        // PUT api/BloodConsumptionRecord/1
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] Guid id, [FromBody] BloodConsumptionRecordRequestDto bloodConsumptionRecordRequestDto)
        {
            var bloodConsumptionRecord = _mapper.Map<BloodConsumptionRecord>(bloodConsumptionRecordRequestDto);
            bloodConsumptionRecord.Id = id;

            try
            {
                var result = _bloodConsumptionRecordService.Update(bloodConsumptionRecord);
                return Ok(result);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE api/BloodConsumptionRecord/1
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                _bloodConsumptionRecordService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
