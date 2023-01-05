using System;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class MedAppSchedulingStatisticsController : ControllerBase
    {

        private readonly IMedAppSchedulingStatisticsService _service;

        public MedAppSchedulingStatisticsController(IMedAppSchedulingStatisticsService service)
        {
            _service = service;
        }

        [HttpGet("times-per-selection")]
        public ActionResult GetTimesPerSelection()
        {
            return Ok(_service.GetTimesPerSelection());
        }
        
        [HttpGet("time-spent-per-selection")]
        public ActionResult GetSpentTimePerSelection()
        {
            return Ok(_service.GetSpentTimePerSelection());
        }
        
        [HttpGet("total-time-spent-per-age-group")]
        public ActionResult GetTotalSpentTimePerAgeGroup()
        {
            return Ok(_service.GetTotalSpentTimePerAgeGroup());
        }
        
        [HttpGet("total-steps-per-age-group")]
        public ActionResult GetTotalStepsPerAgeGroup()
        {
            return Ok(_service.GetTotalStepsPerAgeGroup());
        }
        
        [HttpGet("scheduling-success-rate-per-age-group")]
        public ActionResult GetSchedulingSuccessRatePerAgeGroup()
        {
            return Ok(_service.GetSchedulingSuccessRatePerAgeGroup());
        }
        
        [HttpGet("number-of-chooses-per-doctor")]
        public ActionResult GetNumberOfChoosesPerDoctor()
        {
            return Ok(_service.GetNumberOfChoosesPerDoctor());
        }
    }
}