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
using HospitalAPI.Dtos.Treatment;
using HospitalLibrary.Treatments.Model;
using HospitalLibrary.Treatments.Service;
using HospitalAPI.Dtos.Medicine;
using HospitalLibrary.Medicines.Model;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentService _treatmentService;
        private readonly IMapper _mapper;
        public TreatmentController(ITreatmentService treatmentService, IMapper mapper)
        {
            _treatmentService = treatmentService;
            _mapper = mapper;
        }
        //GET: api/Treatment
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_treatmentService.GetAll());
        }
        //POST: api/Treatment
        [HttpPost]
        public ActionResult Create([FromBody] TreatmentRequestDto treatmentRequestDto)
        {
            var treatment = _mapper.Map<Treatment>(treatmentRequestDto);
            _treatmentService.Create(treatment);
            return CreatedAtAction("GetById", new { id = treatment.Id }, treatment);
        }
        //DELETE: api/Treatment/222
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                _treatmentService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
