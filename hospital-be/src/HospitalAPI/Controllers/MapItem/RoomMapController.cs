using AutoMapper;
using HospitalAPI.Dtos.MapItem;
using HospitalLibrary;
using HospitalLibrary.BuildingManagmentMap.Model;
using HospitalLibrary.BuildingManagmentMap.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace HospitalAPI.Controllers.MapItem
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class RoomMapController : ControllerBase
    {
        private readonly IRoomMapService _roomMapService;
        private readonly IMapper _mapper;

        public RoomMapController(IRoomMapService roomMapService, IMapper mapper)
        {
            _roomMapService = roomMapService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_roomMapService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] Guid id)
        {
            try
            {
                var roomMap = _roomMapService.GetById(id);
                return Ok(roomMap);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] RoomMapRequestDto dto)
        {
            var roomMap = _mapper.Map<RoomMap>(dto);
            _roomMapService.Create(roomMap);
            return CreatedAtAction("GetById", new { id = roomMap.Id }, roomMap);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] Guid id, [FromBody] RoomMapRequestDto dto)
        {
            var roomMap = _mapper.Map<RoomMap>(dto);
            roomMap.Id = id;

            try
            {
                var result = _roomMapService.Update(roomMap);
                return Ok(result);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                _roomMapService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
        [HttpGet("ByFloor/{id}")]
        public ActionResult Get([FromRoute] Guid id)
        {
            return Ok(_roomMapService.GetRoomMapsByFloorId(id));
        }

        [HttpGet("CheckAdjacentRooms/{id1}/{id2}")]
        public ActionResult CheckAdjacentRooms([FromRoute] Guid id1, [FromRoute] Guid id2)
        {
            return Ok(_roomMapService.AreAdjacent(id1, id2));
        }

    }
}
