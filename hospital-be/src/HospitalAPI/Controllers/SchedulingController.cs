using AutoMapper;
using HospitalLibrary;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Patients.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using HospitalLibrary.Core.Service;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulingController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public SchedulingController(IAppointmentService patientService, IMapper mapper)
        {
            _appointmentService = patientService;
            _mapper = mapper;
        }

        // GET api/Available/2
        [HttpGet("{date}")]
        public ActionResult GetAvailableTermins([FromRoute]DateTime date)
        {
            try
            {
                var termins = _appointmentService.AvailableTerminsForDate(date);
                return Ok(termins);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

    }
}
