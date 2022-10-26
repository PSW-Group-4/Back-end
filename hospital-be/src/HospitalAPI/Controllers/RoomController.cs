using AutoMapper;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        }
    
}
