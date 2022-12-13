using AutoMapper;
using HospitalAPI.Dtos.Consilium;
using HospitalLibrary.Consiliums.Model;
using HospitalLibrary.Consiliums.Service;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsiliumController : ControllerBase
    {
        private readonly IConsiliumService _consiliumService;
        private readonly IMapper _mapper;

        public ConsiliumController(IConsiliumService consiliumService, IMapper mapper)
        {
            _consiliumService = consiliumService;
            _mapper = mapper;
        }

        // GET: api/Consilium
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_consiliumService.GetAll());
        }

        // GET api/Consilium/1
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] Guid id)
        {
            try
            {
                var consilium = _consiliumService.GetById(id);
                return Ok(consilium);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // POST api/Consilium
        [HttpPost]
        public ActionResult Create([FromBody] ConsiliumRequestDto consiliumRequestDto)
        {
            var consiliumRequest = _mapper.Map<ConsiliumRequest>(consiliumRequestDto);

            var thisConsilium = _consiliumService.Create(consiliumRequest);

            if (thisConsilium == null)
            {
                return NotFound();
            }
            return Ok(thisConsilium);
        }

        // GET api/Consilium/GetByDoctor/doctorID
        [HttpGet("GetByDoctor/{id}")]
        public ActionResult GetDoctorsConsiliums([FromRoute] Guid id)
        {
            try
            {
                var consilium = _consiliumService.GetDoctorsConsiliums(id);
                return Ok(consilium);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
