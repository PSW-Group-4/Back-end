using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorRoomController : ControllerBase
    {
        

        private readonly IDoctorRoomService _roomService;
        private readonly IMapper _mapper;

        public DoctorRoomController(IDoctorRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_roomService.GetAll());
        }


    }
}