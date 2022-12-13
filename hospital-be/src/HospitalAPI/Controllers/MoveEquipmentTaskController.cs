using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.MoveEquipment.Service.Interfaces;
using HospitalLibrary.MoveEquipment.Model;
namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoveEquipmentAppointmentController : ControllerBase
    {
        private readonly IMoveEquipmentAppointmentService _moveEquipmentTask;
        private readonly IMapper _mapper;
        
        public MoveEquipmentAppointmentController(IMoveEquipmentAppointmentService moveEquipmentTask, IMapper mapper)
            {
                _moveEquipmentTask = moveEquipmentTask;
                _mapper = mapper;
            }

        [HttpPost]
        public ActionResult Create([FromBody] InputCreateData taskDto)
        {
                InputCreateData data = taskDto;
                _moveEquipmentTask.CreateMoveEquipment(data);
                return Ok();

        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_moveEquipmentTask.GetAll());
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            
            _moveEquipmentTask.Delete(id);
            return NoContent();
            
        }
    }
}