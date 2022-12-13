using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.Renovation.Service.Interfaces;
using AutoMapper;
using HospitalLibrary.Renovation.Model;
using HospitalLibrary.Exceptions;

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
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_renovationAppointment.GetAll());
        }

        [HttpPost]
        public ActionResult Create([FromBody] RenovationDataDto taskDto)
        {
                RenovationDataDto data = taskDto;
                _renovationAppointment.CreateRenovation(data);
                return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                _renovationAppointment.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}