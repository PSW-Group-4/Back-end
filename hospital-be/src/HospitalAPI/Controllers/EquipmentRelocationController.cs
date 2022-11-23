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

        // GET api/Available/2
        [HttpGet()]
        public ActionResult GetAll()
        {
            try
            {
                EquipmentRelocation equipmentRelocation = new EquipmentRelocation(new DateTime(2022, 12, 11, 23,0, 0), 30, Guid.Parse("133962ea-c543-497b-81a6-6a2efb54212a"), Guid.Parse("9ae3255d-261f-472f-a961-7f2e7d05d95c"));

                List<DateTime> termins = _equipmentRelocationService.RecommendRelocationStart(equipmentRelocation);
                return Ok(termins);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

    }
}
