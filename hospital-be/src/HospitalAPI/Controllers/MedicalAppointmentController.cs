using System;
using AutoMapper;
using HospitalLibrary;
using HospitalLibrary.Doctors.Service;
using System.Collections.Generic;
using HospitalAPI.Dtos.Appointment;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalAppointmentController : ControllerBase
    {
        private readonly IMedicalAppointmentService _medicalAppointmentService;
        private readonly IMapper _mapper;
        private readonly JwtService _jwtService;
        private readonly DoctorAppointmentService _doctorAppointmentService;
        

        public MedicalAppointmentController(IMedicalAppointmentService medicalAppointmentService, IMapper mapper, JwtService jwtService, DoctorAppointmentService doctorAppointmentService)
        {
            _medicalAppointmentService = medicalAppointmentService;
            _jwtService = jwtService;
            _doctorAppointmentService = doctorAppointmentService;
            _mapper = mapper;
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

        // PUT api/Appointment/1
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] Guid id, [FromBody] AppointmentRequestDto appointmentDto)
        {
            var appointment = _mapper.Map<MedicalAppointment>(appointmentDto);

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

        // DELETE api/Appointment/1
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
        
            [HttpPost("patient-appointment-request-simple")]
            public ActionResult GetAvailableTerminsPatientSide(PatientSideAvailableAppointmentsRequestDto dto)
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

    }
}