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
using HospitalAPI.Dtos.Patient;
using HospitalLibrary.Patients.Model;

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
        //PUT: api/Bed/FreeBed
        [HttpPut("/FreeBed")]
        public ActionResult Update([FromBody] BedDto bedDto)
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
