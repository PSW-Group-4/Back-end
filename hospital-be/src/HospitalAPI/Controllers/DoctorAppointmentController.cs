using System;
using AutoMapper;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("Termins/{timeStart}/{timeEnd}/{patientId}/{doctorId}")]
        public ActionResult getAvailableTerminsForAnotherDoctor([FromRoute] String timeStart, [FromRoute] String timeEnd, [FromRoute] Guid patientId, [FromRoute] Guid doctorId)
        {
            try
            {
                DateTime start = DateTime.Parse(timeStart);
                DateTime end = DateTime.Parse(timeEnd);
                var termins = _doctorAppointmentService.getAvailableTerminsForAnotherDoctor(start, end, patientId, doctorId);
                return Ok(termins);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("Yearly/{id}/{selectedYear}")]
        public ActionResult GetDoctorsYearlyAppointment([FromRoute] Guid id, [FromRoute] int selectedYear)
        {
            return Ok(_doctorAppointmentService.GetAppointmentsPerYear(id, selectedYear));
        }

        [HttpGet("Monthly/{id}/{selectedYear}/{selectedMonth}")]
        public ActionResult GetDoctorsMonthlyAppointment([FromRoute] Guid id, [FromRoute] int selectedYear, [FromRoute] int selectedMonth)
        {
            return Ok(_doctorAppointmentService.GetAppointmentsPerMonth(id, selectedYear, selectedMonth));
        }
    }
}