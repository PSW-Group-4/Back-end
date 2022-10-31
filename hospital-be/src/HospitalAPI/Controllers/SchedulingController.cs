using AutoMapper;
using HospitalLibrary;
using HospitalLibrary.Patients.Service;
using HospitalLibrary.SchedulingAppointment.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulingController : ControllerBase
    {
        private readonly ISchedulingService _schedulingService;
        private readonly IMapper _mapper;

        public SchedulingController(ISchedulingService patientService, IMapper mapper)
        {
            _schedulingService = patientService;
            _mapper = mapper;
        }

        // GET api/Available/2
        [HttpGet("{date}")]
        public ActionResult GetById([FromRoute]DateTime date)
        {
            try
            {
                var patient = _schedulingService.AvailableTerminsForDate(date);
                return Ok(patient);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

    }
}
