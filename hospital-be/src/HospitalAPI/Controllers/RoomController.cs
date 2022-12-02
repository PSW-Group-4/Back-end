using AutoMapper;
using HospitalAPI.Dtos.MapItem;
using HospitalAPI.Dtos.Rooms;
using HospitalLibrary.BuildingManagmentMap.Model;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Exceptions;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class RoomController : ControllerBase
        {
            private readonly IRoomService _roomService;
            private readonly IMapper _mapper;

            public RoomController(IRoomService roomService, IMapper mapper)
            {
                _roomService = roomService;
                _mapper = mapper;
            }

            // GET: api/Room
            [HttpGet]
        public ActionResult GetAll()
            {
                return Ok(_roomService.GetAll());
            }


        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] Guid id, [FromBody] RoomRequestDto dto)
        {
            var room = _mapper.Map<Room>(dto);
            room.Id = id;

            try
            {
                var result = _roomService.Update(room);
                return Ok(result);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

    }
    
}
