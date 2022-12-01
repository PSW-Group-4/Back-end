using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.BuildingManagment.Model;
using HospitalLibrary.BuildingManagment.Service.Interfaces;
using HospitalAPI.Mapper;

namespace HospitalAPI.Controllers.MapItem
{
    [ApiController]
    [Route("api/[controller]")]
    public class FloorController : ControllerBase
    {
        private readonly IFloorService _floorService;
        private readonly IMapper _mapper;

        public FloorController(IFloorService floorService, IMapper mapper)
        {
            _floorService = floorService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_floorService.GetAll());
        }

        [HttpGet("GetRoomsByFloorId/{id}")]
        public ActionResult Get([FromRoute] Guid id)
        {
            return Ok(_floorService.GetRoomsByFloorId(id));
        }
    }
}