using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using HospitalLibrary;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: api/Patient
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_patientService.GetAll());
        }

        // GET api/Patient/2
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute]Guid id)
        {
            try
            {
                var patient = _patientService.GetById(id);
                return Ok(patient);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // POST api/Patient
        [HttpPost]
        public ActionResult Create([FromBody]Patient patient)
        {
            _patientService.Create(patient);
            return CreatedAtAction("GetById", new { id = patient.Id }, patient);
        }

        // PUT api/Patient/2
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute]Guid id,[FromBody] Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            try
            {
                _patientService.Update(patient);
            }
            catch
            {
                return BadRequest();
            }
            return Ok(patient);
        }

        // DELETE api/Patient/2
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute]Guid id)
        {
            try
            {
                _patientService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
