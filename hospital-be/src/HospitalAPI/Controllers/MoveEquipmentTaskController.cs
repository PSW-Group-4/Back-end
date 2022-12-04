using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.MoveEquipment.Service.Interfaces;
using HospitalLibrary.MoveEquipment.Model;
using HospitalLibrary.Vacations.Model;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoveEquipmentTaskController : ControllerBase
    {
        private readonly IMoveEquipmentTaskService _moveEquipmentTask;
        private readonly IMapper _mapper;
        
        public MoveEquipmentTaskController(IMoveEquipmentTaskService moveEquipmentTask, IMapper mapper)
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

        /*[HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_moveEquipmentTask.GetAll());
        }

        [HttpPost]
        public ActionResult Create2([FromBody] InputCreateData taskDto)
        {
            var task = _mapper.Map<MoveEquipmentTask>(taskDto);

            var newTask = _moveEquipmentTask.Create(task);

            if (newTask == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetById", new { id = task.Id }, task);

        }*/
    }
}