using System;
using AutoMapper;
using HospitalLibrary;
using HospitalLibrary.Doctors.Service;
using System.Collections.Generic;
using HospitalAPI.Dtos.Appointment;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Users.Model;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.Collections;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalAppointmentController : ControllerBase
    {
        private readonly IMedicalAppointmentService _medicalAppointmentService;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public MedicalAppointmentController(IMedicalAppointmentService medicalAppointmentService, IMapper mapper, IJwtService jwtService)
        {
            _medicalAppointmentService = medicalAppointmentService;
            _mapper = mapper;
            _jwtService = jwtService;
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
                return Ok(appsDto);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("get-all-future")]
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
                return Ok(appsDto);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("get-all-canceled")]
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
                return Ok(appsDto);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}