using System;
using System.Net.Http;
using HospitalAPI.Dtos.MedicalAppointmentEventSourcing;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Exceptions;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalAppointmentSchedulingEventSourcingController : ControllerBase
    {
        private readonly IMedicalAppointmentSchedulingEventSourcingService _sessionService;
        private readonly IJwtService _jwtService;

        public MedicalAppointmentSchedulingEventSourcingController(IMedicalAppointmentSchedulingEventSourcingService sessionService, IJwtService jwtService)
        {
            _sessionService = sessionService;
            _jwtService = jwtService;
        }
        
        [HttpPost("start-scheduling")]
        [Authorize(Roles = "Patient")]
        public ActionResult StartScheduling([FromBody] StartSchedulingDto dto)
        {
            try
            {
                Guid? patientId = _jwtService.GetCurrentUser(HttpContext.User).PersonId;
                if (patientId == null)
                {
                    return BadRequest();
                }
                
                Guid aggregateId = _sessionService.StartScheduling((Guid)patientId, dto.OccurenceTime.ToLocalTime());
                return Ok(aggregateId);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("choose-date")]
        [Authorize(Roles = "Patient")]
        public ActionResult ChooseDate([FromBody] ChooseDateDto dto)
        {
            _sessionService.ChooseDate(dto.AggregateId, dto.Date, dto.OccurenceTime.ToLocalTime());
            return Ok();
        }
        
        [HttpPost("choose-speciality")]
        [Authorize(Roles = "Patient")]
        public ActionResult ChooseSpeciality([FromBody] ChooseSpecialityDto dto)
        {
            _sessionService.ChooseSpeciality(dto.AggregateId, dto.Speciality, dto.OccurenceTime.ToLocalTime());
            return Ok();
        }

        [HttpPost("choose-doctor")]
        [Authorize(Roles = "Patient")]
        public ActionResult ChooseDoctor([FromBody] ChooseDoctorDto dto)
        {
            try
            {
                _sessionService.ChooseDoctor(dto.AggregateId, dto.DoctorId, dto.OccurenceTime.ToLocalTime());
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
        
        [HttpPost("finish-scheduling")]
        [Authorize(Roles = "Patient")]
        public ActionResult FinishScheduling([FromBody] FinishSchedulingDto dto)
        {
            _sessionService.FinishScheduling(dto.AggregateId, dto.Time.ToLocalTime(), dto.OccurenceTime.ToLocalTime());
            return Ok();
        }

        [HttpPost("go-back-to-selection")]
        [Authorize(Roles = "Patient")]
        public ActionResult GoBackToSelection([FromBody] GoBackToSelectionDto dto)
        {
            _sessionService.GoBackToSelection(dto.AggregateId, dto.Selection, dto.OccurenceTime.ToLocalTime());
            return Ok();
        }
    }

}