using AutoMapper;
using HospitalLibrary.Allergies.Service;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergieController : ControllerBase
    {
        private readonly IAllergieService _allergieService;
        private readonly IMapper _mapper;

        public AllergieController(IMapper mapper, IAllergieService allergieService)
        {
            _mapper = mapper;
            _allergieService = allergieService;
        }

        [HttpGet("get-all")]
        public ActionResult GetAll()
        {
            var a = _allergieService.GetAll();
            //_mapper.Map<IEnumerable<AllergieInfoDto>>(a)
            return Ok(a);
        }
    }
}