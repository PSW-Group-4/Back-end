using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using HospitalAPI.Dtos.Report;
using HospitalLibrary.Reports.Model;
using HospitalLibrary.Reports.Service;
using AutoMapper;
using HospitalLibrary.AdmissionHistories.Model;
using HospitalLibrary.AdmissionHistories.Service;
using HospitalLibrary.AppointmentReport.Service;
using iTextSharp.text;
using System.Collections.Generic;
using HospitalLibrary.AppointmentReport.Model;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        private readonly IMedicalAppointmentReportService _appointmentReportService;
        private readonly IMapper _mapper;

        public ReportController(IReportService reportService,IMedicalAppointmentReportService appointmentReportService, IMapper mapper)
        {
            _reportService = reportService;
            _appointmentReportService = appointmentReportService;
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

        [HttpGet("get-by-appointment-id/{id}")]
        public ActionResult GetByAppointmentId([FromRoute] Guid id)
        {
            try
            {
                Report report = _reportService.GetByMedicalAppointmentId(id);
                return Ok(report.Id);
            }
            catch (NotFoundException)
            {
                return NotFound("Chosen medical appointment has no reports");
            }
        }

        [HttpGet("symptom/{name}")]
        public ActionResult GetBySymptom([FromRoute] String name)
        {
            try
            {
                return Ok(_reportService.GetBySymptom(name));
            }
            catch (NotFoundException)
            {
                return NotFound("Not found");
            }
        }

        [HttpGet("prescription/{name}")]
        public ActionResult GetByPrescription([FromRoute] String name)
        {
            try
            {
                return Ok(_reportService.GetByPrescription(name));
            }
            catch (NotFoundException)
            {
                return NotFound("Not found");
            }
        }
        [HttpGet("patientName/{name}")]
        public ActionResult GetByPatientName([FromRoute] String name)
        {
            try
            {
                return Ok(_reportService.GetByPatientName(name));
            }
            catch (NotFoundException)
            {
                return NotFound("Not found");
            }
        }
        [HttpGet("patientSurname/{name}")]
        public ActionResult GetByPatientSurname([FromRoute] String name)
        {
            try
            {
                return Ok(_reportService.GetByPatientSurname(name));
            }
            catch (NotFoundException)
            {
                return NotFound("Not found");
            }
        }
        [HttpGet("search/{name}")]
        public ActionResult BasicSearch([FromRoute] String name)
        {
            try
            {
                return Ok(_reportService.BasicSearch(name));
            }
            catch (NotFoundException)
            {
                return NotFound("Not found");
            }
        }
        [HttpGet("advancedSearch/{name}")]
        public ActionResult AdvancedSearch([FromRoute] String name)
        {
            try
            {
                return Ok(_reportService.AdvancedSearch(name));
            }
            catch (NotFoundException)
            {
                return NotFound("Not found");
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
            var reportMap = _mapper.Map<Report>(reportRequestDto);
            //report.Id = id;

            Report report = new Report(
                id,
                reportMap.MedicalAppointmentId,
                reportMap.Text,
                reportMap.Symptoms,
                reportMap.Prescriptions,
                reportMap.DateTime
        );



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

        [HttpGet("GeneratePdf/{id}/{settings}")]
        public ActionResult GenerateSeveralPdf([FromRoute] Guid id, [FromRoute] List<String> settings)
        {
            try
            {
                Report report = _reportService.GetById(id);
                return File(_appointmentReportService.GeneratePdf(new MedicalAppointmentReport(report,settings)), "application/pdf", "medicalReport.pdf");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
