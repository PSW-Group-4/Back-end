using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HospitalLibrary.MedicalAppointmentReportSession.Service;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class MedAppReportStatisticsController : ControllerBase
    {
        private readonly IMedAppReportStatisticsService _service;

        public MedAppReportStatisticsController(IMedAppReportStatisticsService service)
        {
            _service = service;
        }


        [HttpGet("reportTable")]
        public ActionResult GetReportTable()
        {
            return Ok(_service.GetReportTable());
        }

        [HttpGet("numberSteps")]
        public ActionResult GetNumberSteps()
        {
            return Ok(_service.GetNumberSteps());
        }

        [HttpGet("numberEachStep")]
        public ActionResult GetNumberEachStep()
        {
            return Ok(_service.GetNumberEachStep());
        }

        [HttpGet("timeSteps")]
        public ActionResult GetTimeSteps()
        {
            return Ok(_service.GetTimeSteps());
        }

        [HttpGet("timeEachStep")]
        public ActionResult GetTimeEachStep()
        {
            return Ok(_service.GetTimeEachStep());
        }

        [HttpGet("doctorTimeSteps")]
        public ActionResult GetDoctorTimeSteps()
        {
            return Ok(_service.GetDoctorTimeSteps());
        }
    }
}
