using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.Renovation.Service.Interfaces;
using AutoMapper;
using HospitalLibrary.Renovation.Model;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RenovationAppointmentController : ControllerBase
    {
        private readonly IRenovationAppointmentService _renovationAppointment;
        private readonly IMapper _mapper;
        
        public RenovationAppointmentController(IRenovationAppointmentService renovationAppointment, IMapper mapper)
            {
                _renovationAppointment = renovationAppointment;
                _mapper = mapper;
            }

        [HttpPost]
        public ActionResult Create([FromBody] RenovationDataDto taskDto)
        {
                RenovationDataDto data = taskDto;
                _renovationAppointment.CreateRenovation(data);
                return Ok();

        }
    }
}