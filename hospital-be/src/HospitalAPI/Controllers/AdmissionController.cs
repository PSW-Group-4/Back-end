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

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionController : ControllerBase
    {
        private readonly IAdmissionService _admissionService;
        private readonly IMapper _mapper;

        public AdmissionController(IAdmissionService admissionService, IMapper mapper)
        {
            _admissionService = admissionService;
            _mapper = mapper;
        }

        // GET: api/Admission
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_admissionService.GetAll());
        }

        // GET: api/Admission/1
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] Guid id)
        {
            try
            {
                var admission = _admissionService.GetById(id);
                return Ok(admission);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // POST api/Admission
        [HttpPost]
        public ActionResult Create([FromBody] AdmissionRequestDto admissionDto)
        {
            try { 
            var admission = _mapper.Map<Admission>(admissionDto);
            _admissionService.Create(admission);
            return CreatedAtAction("GetById", new { id = admission.Id }, admission);
            }
            catch(NotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE api/Admission/1
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                _admissionService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // PUT api/Admission/treatmentId
        [HttpPut("{treatmentId}")]
        public ActionResult UpdateTreatment([FromRoute] Guid treatmentId, [FromBody] AdmissionUpdateTreatmentDto admissionUpdateTreatmentDto)
        {
            var admission = _mapper.Map<Admission>(admissionUpdateTreatmentDto);
            try
            {
                var result = _admissionService.UpdateTreatment(admission, treatmentId);
                return Ok(result);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
    
}
