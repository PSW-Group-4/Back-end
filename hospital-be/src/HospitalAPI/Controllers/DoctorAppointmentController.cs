﻿using AutoMapper;
using HospitalLibrary;
using HospitalLibrary.Appointments.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using HospitalLibrary.Exceptions;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAppointmentController : ControllerBase
    {

        private readonly IDoctorAppointmentService _doctorAppointmentService;
        private readonly IMapper _mapper;

        public DoctorAppointmentController(IDoctorAppointmentService doctorAppointmentService, IMapper mapper)
        {
            _doctorAppointmentService = doctorAppointmentService;
            _mapper = mapper;
        }

        // GET: api/DoctorAppointment/DoctorId
        [HttpGet("{id}")]
        public ActionResult GetDoctorAppointments([FromRoute] Guid id)
        {
            try
            {
                return Ok(_doctorAppointmentService.GetDoctorAppointments(id));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // GET: api/DoctorAppointment/Old/DoctorId
        [HttpGet("Old/{id}")]
        public ActionResult GetDoctorsOldAppoinments([FromRoute] Guid id)
        {
            return Ok(_doctorAppointmentService.GetDoctorsOldAppointments(id));
        }

        // GET: api/DoctorAppointment/Current/Doctor/1
        [HttpGet("Current/{id}")]
        public ActionResult GetDoctorsCurrentAppoinments([FromRoute] Guid id)
        {
            return Ok(_doctorAppointmentService.GetDoctorsCurrentAppointments(id));
        }

        // DELETE api/DoctorAppointment/Email/AppointmentId
        [HttpDelete("Email/{id}")]
        public ActionResult deleteAppointmentEndSendNotification([FromRoute] Guid id)
        {
            try
            {
                _doctorAppointmentService.deleteAppointmentEndSendNotification(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}