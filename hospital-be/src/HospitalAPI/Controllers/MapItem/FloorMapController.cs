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
    public class FloorMapController : ControllerBase
    {
        private readonly IFloorMapService _floorMapService;
        private readonly IMapper _mapper;

        public FloorMapController(IFloorMapService floorMapService, IMapper mapper)
        {
            _floorMapService = floorMapService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_floorMapService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] Guid id)
        {
            try
            {
                var buildingMap = _floorMapService.GetById(id);
                return Ok(buildingMap);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] FloorMapRequestDto dto)
        {
            var floorMap = _mapper.Map<FloorMap>(dto);
            _floorMapService.Create(floorMap);
            return CreatedAtAction("GetById", new { id = floorMap.Id }, floorMap);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] Guid id, [FromBody] FloorMapRequestDto dto)
        {
            var floor = _mapper.Map<FloorMap>(dto);
            floor.Id = id;

            try
            {
                var result = _floorMapService.Update(floor);
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
                _floorMapService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("ByBuilding/{id}")]
        public ActionResult Get([FromRoute] Guid id)
        {
            return Ok(_floorMapService.GetFloorMapsByBuildingId(id));
        }
    }
}
