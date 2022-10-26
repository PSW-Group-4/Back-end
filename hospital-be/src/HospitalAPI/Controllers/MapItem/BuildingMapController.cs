using AutoMapper;
using HospitalAPI.Dtos.MapItem;
using HospitalLibrary;
using HospitalLibrary.BuildingManagmentMap.Model;
using HospitalLibrary.BuildingManagmentMap.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
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
            return CreatedAtAction("GetById", new { id = buildingMap.Guid }, buildingMap);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] Guid id, [FromBody] BuildingMapRequestDto dto)
        {
            var building = _mapper.Map<BuildingMap>(dto);
            building.Guid = id;

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
