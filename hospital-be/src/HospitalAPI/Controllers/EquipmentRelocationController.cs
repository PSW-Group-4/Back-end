using AutoMapper;
using HospitalLibrary;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Patients.Service;
using HospitalLibrary.SchedulingAppointment.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using HospitalLibrary.EquipmentRelocation.Service;
using HospitalLibrary.EquipmentRelocation.DTO;
using HospitalLibrary.Appointments.Service;
using System.Collections.Generic;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentRelocationController : ControllerBase
    {
        private readonly IEquipmentRelocationService _equipmentRelocationService;
        private readonly IMapper _mapper;
        public EquipmentRelocationController(IEquipmentRelocationService service, IMapper mapper)
        {
            _equipmentRelocationService = service;
            _mapper = mapper;
        }


        
        [HttpGet("Recommend/{relocationStart}/{duration}/{sourceId}/{targetId}")]
        public ActionResult Recommend([FromRoute] String relocationStart, [FromRoute] int duration, [FromRoute] String sourceId, [FromRoute] String targetId)
        {
            try
            {
                DateTime dateTime= DateTime.Parse(relocationStart);
                EquipmentRelocationDTO equipmentRelocation = new EquipmentRelocationDTO(dateTime, duration, Guid.Parse(sourceId), Guid.Parse(targetId));

                List<DateTime> termins = _equipmentRelocationService.RecommendRelocationStart(equipmentRelocation);
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
            return Ok(_equipmentRelocationService.GetAll());
        }

    }
}
