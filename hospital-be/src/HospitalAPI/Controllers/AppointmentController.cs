using System;
using AutoMapper;
using HospitalAPI.Dtos.Appointment;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentService appointmentService, IDoctorService doctorService,
            IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        // GET: api/Appointment
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_appointmentService.GetAll());
        }

        // GET api/Appointment/1
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] Guid id)
        {
            try
            {
                var appointment = _appointmentService.GetById(id);
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
            var appointment = _mapper.Map<Appointment>(appointmentDto);
            _appointmentService.Create(appointment);
            return CreatedAtAction("GetById", new { id = appointment.Id }, appointment);
        }

        // PUT api/Appointment/1
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] Guid id, [FromBody] AppointmentRequestDto appointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(appointmentDto);
            appointment.Id = id;

            try
            {
                var result = _appointmentService.Update(appointment);
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
                _appointmentService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}