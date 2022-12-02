using System;
using AutoMapper;
using HospitalAPI.Dtos.MapItem;
using HospitalLibrary.BuildingManagmentMap.Model;
using HospitalLibrary.BuildingManagmentMap.Service.Interfaces;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers.MapItem
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Manager")]
    public class BuildingMapController : ControllerBase
    {

        private readonly IBuildingMapService _buildingMapService;
        private readonly IMapper _mapper;

        public BuildingMapController(IBuildingMapService buildingMapService, IMapper mapper)
        {
            this._buildingMapService = buildingMapService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_buildingMapService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] Guid id)
        {
            try
            {
                var buildingMap = _buildingMapService.GetById(id);
                return Ok(buildingMap);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Create([FromBody] BuildingMapRequestDto dto)
        {
            var buildingMap = _mapper.Map<BuildingMap>(dto);
            _buildingMapService.Create(buildingMap);
            return CreatedAtAction("GetById", new { id = buildingMap.Id }, buildingMap);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] Guid id, [FromBody] BuildingMapRequestDto dto)
        {
            var building = _mapper.Map<BuildingMap>(dto);
            building.Id = id;

            try
            {
                var result = _buildingMapService.Update(building);
                return Ok(result);
            }
            catch(NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                _buildingMapService.Delete(id);
                return NoContent();
            }
            catch(NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
