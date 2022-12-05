using AutoMapper;
using HospitalLibrary;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Patients.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using HospitalLibrary.Core.Service;
using HospitalLibrary.EquipmentRelocation.DTO;
using System.Collections.Generic;
using HospitalLibrary.Core.Model;
using HospitalAPI.Dtos.Appointment;

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

        [HttpGet("Recommend/{relocationStart}/{duration}/{sourceId}/{targetId}")]
        public ActionResult Recommend([FromRoute] String relocationStart, [FromRoute] int duration, [FromRoute] String sourceId, [FromRoute] String targetId)
        {
            try
            {
                DateTime dateTime = DateTime.Parse(relocationStart);
                EquipmentRelocationDTO equipmentRelocation = new EquipmentRelocationDTO(new HospitalLibrary.Core.Model.DateRange(dateTime, dateTime.AddDays(2)), duration, Guid.Parse(sourceId), Guid.Parse(targetId));

                List<DateTime> termins = _appointmentService.RecommendStartForRelocationOrRenovation(equipmentRelocation);
                return Ok(termins);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_appointmentService.GetAll());
        }

        [HttpPost]
        public ActionResult Create(AppointmentDto appDto)
        {
            var app = _mapper.Map<Appointment>(appDto);
            return Ok(_appointmentService.Create(app));
        }
    }
}
