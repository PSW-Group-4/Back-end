using AutoMapper;
using HospitalAPI.Dtos.Appointment;
using HospitalLibrary;
using HospitalLibrary.Admissions.Service;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;
using HospitalAPI.Dtos.Admission;
using System;
using HospitalLibrary.Admissions.Model;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using HospitalAPI.Dtos.Bed;
using HospitalLibrary.RoomsAndEqipment.Model;

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

        //POST: api/Bed
        [HttpPost]

        public ActionResult Create([FromBody] BedDto bedDto)
        {
            var bed = _mapper.Map<Bed>(bedDto);
            _bedService.Create(bed);
            return CreatedAtAction("GetById", new { id = bed.Id }, bed);

        }

        //DELETE: api/Bed/222
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]Guid id)
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
