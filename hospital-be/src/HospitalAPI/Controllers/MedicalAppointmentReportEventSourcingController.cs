using System;
using System.Net.Http;
using HospitalAPI.Dtos.MedicalAppointmentEventSourcing;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Exceptions;
using HospitalLibrary.MedicalAppointmentReportSession.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalAppointmentReportEventSourcingController : ControllerBase
    {
        private readonly IMedicalAppointmentReportEventSourcingService _sessionService;
        private readonly IJwtService _jwtService;

        public MedicalAppointmentReportEventSourcingController(IMedicalAppointmentReportEventSourcingService sessionService, IJwtService jwtService)
        {
            _sessionService = sessionService;
            _jwtService = jwtService;
        }

        [HttpPost("start-scheduling")]
        [Authorize(Roles = "Doctor")]
        public ActionResult StartScheduling([FromBody] StartSchedulingDto dto)
        {
            try
            {
                Guid? doctorId = _jwtService.GetCurrentUser(HttpContext.User).PersonId;
                if (doctorId == null)
                {
                    return BadRequest();
                }

                Guid aggregateId = _sessionService.StartScheduling((Guid)doctorId, dto.OccurenceTime.ToLocalTime());
                return Ok(aggregateId);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("choose-symptom")]
        [Authorize(Roles = "Doctor")]
        public ActionResult ChooseSymptom([FromBody] ChooseSymptomDto dto)
        {
            _sessionService.ChooseSymptom(dto.AggregateId, dto.NumberOfSymptoms, dto.OccurenceTime.ToLocalTime());
            return Ok();
        }

        [HttpPost("choose-report-text")]
        [Authorize(Roles = "Doctor")]
        public ActionResult ChooseReportText([FromBody] ChooseReportTextDto dto)
        {
            _sessionService.ChooseReportText(dto.AggregateId, dto.ReportText, dto.OccurenceTime.ToLocalTime());
            return Ok();
        }

        [HttpPost("choose-medicine")]
        [Authorize(Roles = "Doctor")]
        public ActionResult ChooseMedicine([FromBody] ChooseMedicineDto dto)
        {
            try
            {
                _sessionService.ChooseMedicine(dto.AggregateId, dto.NumberOfMedicines, dto.OccurenceTime.ToLocalTime());
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("finish-scheduling")]
        [Authorize(Roles = "Doctor")]
        public ActionResult FinishScheduling([FromBody] FinishSchedulingDto dto)
        {
            _sessionService.FinishScheduling(dto.AggregateId, dto.Time.ToLocalTime(), dto.OccurenceTime.ToLocalTime());
            return Ok();
        }

        [HttpPost("go-back-to-selection")]
        [Authorize(Roles = "Doctor")]
        public ActionResult GoBackToSelection([FromBody] GoBackToSelectionReportDto dto)
        {
            _sessionService.GoBackToSelection(dto.AggregateId, dto.Selection, dto.OccurenceTime.ToLocalTime());
            return Ok();
        }
    }
}
