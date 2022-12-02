using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using HospitalAPI.Dtos.Prescription;
using HospitalLibrary.Prescriptions.Model;
using HospitalLibrary.Prescriptions.Service;
using AutoMapper;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;
        private readonly IMapper _mapper;

        public PrescriptionController(IPrescriptionService prescriptionService, IMapper mapper)
        {
            _prescriptionService = prescriptionService;
            _mapper = mapper;
        }

        //GET: api/Prescription
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_prescriptionService.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] Guid id)
        {
            try
            {
                var patient = _prescriptionService.GetById(id);
                return Ok(patient);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
        //POST: api/Prescription
        [HttpPost]
        public ActionResult Create([FromBody] PrescriptionRequestDto prescriptionRequestDto)
        {
            var prescription = _mapper.Map<Prescription>(prescriptionRequestDto);
            _prescriptionService.Create(prescription);
            return CreatedAtAction("GetById", new { id = prescription.Id }, prescription);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] Guid id, [FromBody] PrescriptionRequestDto prescriptionRequestDto)
        {
            var prescription = _mapper.Map<Prescription>(prescriptionRequestDto);
            prescription.Id = id;

            try
            {
                var result = _prescriptionService.Update(prescription);
                return Ok(result);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        //DELETE: api/Prescription/222
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                _prescriptionService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
