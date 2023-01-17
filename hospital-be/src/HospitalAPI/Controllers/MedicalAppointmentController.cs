using System;
using AutoMapper;
using HospitalLibrary;
using HospitalLibrary.Doctors.Service;
using System.Collections.Generic;
using HospitalAPI.Dtos.Appointment;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Users.Model;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Collections;
using System.Linq;
using HospitalLibrary.Utility;
using HospitalLibrary.Patients.Service;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Users.Service;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalAppointmentController : ControllerBase
    {
        private readonly IMedicalAppointmentService _medicalAppointmentService;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        private readonly IDoctorAppointmentService _doctorAppointmentService;
        private readonly IDoctorService _doctorService;
        private readonly IUserService _userService;
        //private readonly IPatientService _patientService;

        public MedicalAppointmentController(IMedicalAppointmentService medicalAppointmentService, 
            IMapper mapper, IJwtService jwtService, IDoctorAppointmentService doctorAppointmentService,
            IDoctorService doctorService, IUserService userService)
        {
            _medicalAppointmentService = medicalAppointmentService;
            _jwtService = jwtService;
            _doctorAppointmentService = doctorAppointmentService;
            _mapper = mapper;
            _jwtService = jwtService;
            _doctorService = doctorService;
            //_patientService = patientService;
            _userService = userService;
        }

        // GET: api/Appointment
        [HttpGet]
        public ActionResult GetAll()
        { 
            return Ok(_medicalAppointmentService.GetAll());
        }

        // GET api/Appointment/1
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] Guid id)
        {
            try
            {
                var appointment = _medicalAppointmentService.GetById(id);
                return Ok(appointment);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // POST api/Appointment
        [HttpPost]
        public ActionResult Create([FromBody] AppointmentRequestDto appointmentDto)
        {
            var appointment = _mapper.Map<MedicalAppointment>(appointmentDto);
            _medicalAppointmentService.Create(appointment);
            return CreatedAtAction("GetById", new { id = appointment.Id }, appointment);
        }

        [HttpPost("schedule-patient")]
        [Authorize(Roles = "Patient")]
        public ActionResult ScheduleAppointmentPatient([FromBody] AppointmentRequestPatientDto request)
        {
            var doctor = _doctorService.GetById(request.DoctorId);
            var patientId = 
                _jwtService.GetCurrentUser(HttpContext.User).PersonId ?? throw new NotFoundException();

            request.Date =request.Date.AddHours(1);
            var dateRange = new DateRange(request.Date, request.Date.AddMinutes(30));
            var appointment = new MedicalAppointment(Guid.NewGuid(), dateRange, doctor.RoomId, null, doctor.Id, null,
                patientId, null, false);
            // appointment.PatientId = patientId;
            // appointment.RoomId = doctor.RoomId;

            _medicalAppointmentService.Create(appointment);
            return CreatedAtAction("GetById", new { id = appointment.Id }, appointment);
        }

        // PUT api/Appointment/1
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] Guid id, [FromBody] AppointmentRequestDto appointmentDto)
        {
            var appointment = _mapper.Map<MedicalAppointment>(appointmentDto);
            appointment.Id = id;
            try
            {
                var result = _medicalAppointmentService.Update(appointment);
                return Ok(result);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
        
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                _medicalAppointmentService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("cancel/{id}")]
        [Authorize(Roles = "Patient")]
        public ActionResult Cancel([FromRoute] Guid id)
        {
            try
            {
                User user = _jwtService.GetCurrentUser(HttpContext.User);
                if (user.PersonId == null)
                {
                    return BadRequest("Only patients can cacnel");
                }

                _medicalAppointmentService.Cancel(id, (Guid)user.PersonId);
                _userService.AddSuspiciousActivityToUser((Guid)user.PersonId, new SuspiciousActivity("Appointment cancellation"));
                return Ok(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch(CanNotCancelAppointmentException e)
            {
                return Conflict(e.Message);
            }
            catch(AlreadyCanceledException)
            {
                return Conflict("Already canceled");
            }

        }

        [HttpGet("get-all-done")]
        [Authorize(Roles = "Patient")]
        public ActionResult GetAllDoneForPatient()
        {
            try
            {
                User user = _jwtService.GetCurrentUser(HttpContext.User);
                if (user.PersonId == null)
                {
                    return BadRequest("Only patient can view their appointments");
                }

                var appointments = _medicalAppointmentService.GetDoneByPatient((Guid)user.PersonId);
                var appsDto = new List<MedicalAppointmentDto>();
                foreach(var a in appointments)
                {
                    appsDto.Add(new MedicalAppointmentDto(a));
                }
                //YOLO
                return Ok(appsDto.OrderBy(app => app.StartTime));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("get-all-future")]
        [Authorize(Roles = "Patient")]
        public ActionResult GetAllFutureForPatient()
        {
            try
            {
                User user = _jwtService.GetCurrentUser(HttpContext.User);
                if (user.PersonId == null)
                {
                    return BadRequest("Only patient can view their appointments");
                }

                var appointments = _medicalAppointmentService.GetFutureByPatient((Guid)user.PersonId);
                var appsDto = new List<MedicalAppointmentDto>();
                foreach(var a in appointments)
                {
                    appsDto.Add(new MedicalAppointmentDto(a));
                }
                //YOLO
                return Ok(appsDto.OrderBy(app => app.StartTime));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("get-all-canceled")]
        [Authorize(Roles = "Patient")]
        public ActionResult GetAllCanceledForPatient()
        {
            try
            {
                User user = _jwtService.GetCurrentUser(HttpContext.User);
                if (user.PersonId == null)
                {
                    return BadRequest("Only patient can view their appointments");
                }

                var appointments = _medicalAppointmentService.GetCanceledByPatient((Guid)user.PersonId);
                var appsDto = new List<MedicalAppointmentDto>();
                foreach(var a in appointments)
                {
                    appsDto.Add(new MedicalAppointmentDto(a));
                }
                return Ok(appsDto.OrderBy(app => app.StartTime));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
        
            [Authorize(Roles = "Patient")]
            [HttpPost("patient-appointment-request-simple")]
            public ActionResult GetAvailableTerminsPatientSide([FromBody]PatientSideAvailableAppointmentsRequestDto dto)
            {
                try
                {
                    Guid patientId = _jwtService.GetCurrentUser(HttpContext.User).PersonId ?? throw new NotFoundException();
                    var termins = _doctorAppointmentService.AvailableTerminsForDate(dto.Date, patientId, dto.DoctorId);
                    return Ok(termins);
                }
                catch (NotFoundException)
                {
                    return NotFound();
                }
            }

        [HttpPost("patient-appointment-request-with-suggestions")]
        [Authorize(Roles = "Patient")]
        public ActionResult GetAppointmentSuggestions([FromBody] AppointmentRequestWithSuggestionsDto requestInfo)
        {
            try
            {
                Guid patientId = _jwtService.GetCurrentUser(HttpContext.User).PersonId ?? throw new NotFoundException();
                var request = _mapper.Map<RequestForAppointmentSlotSuggestions>(requestInfo);
                request.RequestingPatientId = patientId;
                request.StartDate = requestInfo.StartDate;
                request.EndDate = requestInfo.EndDate;
                var suggestions = _doctorAppointmentService.GetAppointmentSuggestionsForDateRange(request);
                return Ok(suggestions);

            }
            catch (NotFoundException) {
                return NotFound();  
            }
        }
    }
}