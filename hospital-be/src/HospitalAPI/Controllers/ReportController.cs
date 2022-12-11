using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using HospitalAPI.Dtos.Report;
using HospitalLibrary.Reports.Model;
using HospitalLibrary.Reports.Service;
using AutoMapper;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IMapper _mapper;

        public ReportController(IReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        //GET: api/Report
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_reportService.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] Guid id)
        {
            try
            {
                var patient = _reportService.GetById(id);
                return Ok(patient);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
        //POST: api/Report
        [HttpPost]
        public ActionResult Create([FromBody] ReportRequestDto reportRequestDto)
        {
            var report = _mapper.Map<Report>(reportRequestDto);
            _reportService.Create(report);
            return CreatedAtAction("GetById", new { id = report.Id }, report);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] Guid id, [FromBody] ReportRequestDto reportRequestDto)
        {
            var report = _mapper.Map<Report>(reportRequestDto);
            report.Id = id;

            try
            {
                var result = _reportService.Update(report);
                return Ok(result);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        //DELETE: api/Report/222
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                _reportService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
