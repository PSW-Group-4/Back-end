using AutoMapper;
using HospitalAPI.Dtos.Allergies;
using HospitalLibrary.Allergies.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergieController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAllergieService _allergieService;

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
