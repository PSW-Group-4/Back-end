using AutoMapper;
using HospitalLibrary.Doctors.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        // GET: api/Doctor
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_doctorService.GetAll());
        }
    }
}
