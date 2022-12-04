using AutoMapper;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorRoomController : ControllerBase
    {
        private readonly IMapper _mapper;


        private readonly IDoctorRoomService _roomService;

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