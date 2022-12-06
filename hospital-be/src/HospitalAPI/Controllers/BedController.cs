using System;
using AutoMapper;
using HospitalAPI.Dtos.Bed;
using HospitalLibrary.Exceptions;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BedController : ControllerBase
    {
        private readonly IBedService _bedService;
        private readonly IMapper _mapper;

        public BedController(IBedService bedService, IMapper mapper)
        {
            _bedService = bedService;
            _mapper = mapper;
        }

        //GET: api/Bed
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_bedService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] Guid id)
        {
            try
            {
                var patient = _bedService.GetById(id);
                return Ok(patient);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        //POST: api/Bed
        [HttpPost]
        public ActionResult Create([FromBody] BedDto bedDto)
        {
            var bed = _mapper.Map<Bed>(bedDto);
            _bedService.Create(bed);
            return CreatedAtAction("GetById", new { id = bed.Id }, bed);
        }

        //PUT: api/Bed/FreeBed
        [HttpPut("/FreeBed")]
        public ActionResult FreeBed([FromBody] BedDto bedDto)
        {
            var bed = _mapper.Map<Bed>(bedDto);
            //bed.Id = id;

            try
            {
                var result = _bedService.FreeBed(bed);
                return Ok(result);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        //PUT: api/Bed/CaptureBed
        [HttpPut("/CaptureBed")]
        public ActionResult CaptureBed([FromBody] BedDto bedDto)
        {
            var bed = _mapper.Map<Bed>(bedDto);
            //bed.Id = id;

            try
            {
                var result = _bedService.CaptureBed(bed);
                return Ok(result);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }


        //DELETE: api/Bed/222
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                _bedService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}