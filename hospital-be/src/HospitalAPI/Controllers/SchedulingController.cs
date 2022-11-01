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
        public ActionResult GetAvailableTermins([FromRoute]DateTime date)
        {
            try
            {
                var termins = _schedulingService.AvailableTerminsForDate(date);
                return Ok(termins);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

    }
}
