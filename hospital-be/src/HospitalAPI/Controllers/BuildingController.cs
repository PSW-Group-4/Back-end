using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.BuildingManagment.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuildingController : ControllerBase
    {
        private readonly IBuildingService _buildingService;
        private readonly IMapper _mapper;

        public BuildingController(IBuildingService buildingService, IMapper mapper)
        {
            _buildingService = buildingService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public ActionResult GetAll()
        {
            return Ok(_buildingService.GetAll());
        }

        [HttpGet("GetFloorsByBuildingId/{id}")]
        [Authorize(Roles = "Manager")]
        public ActionResult Get([FromRoute] Guid id)
        {
            return Ok(_buildingService.GetFloorsByBuildingId(id));
        }
    }
}