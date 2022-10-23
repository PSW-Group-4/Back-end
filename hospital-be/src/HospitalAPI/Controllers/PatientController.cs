using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientervice;

        public PatientController(IPatientService Patientervice)
        {
            _patientervice = Patientervice;
        }

        // GET: api/Patient
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_patientervice.GetAll());
        }

        // GET api/Patient/2
        [HttpGet("{id}")]
        public ActionResult GetById(Guid id)
        {
            var patient = _patientervice.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }

        // POST api/Patient
        [HttpPost]
        public ActionResult Create(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _patientervice.Create(patient);
            return CreatedAtAction("GetById", new { id = patient.Id }, patient);
        }

        // PUT api/Patient/2
        [HttpPut("{id}")]
        public ActionResult Update(Guid id, Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patient.Id)
            {
                return BadRequest();
            }

            try
            {
                _patientervice.Update(patient);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(patient);
        }

        // DELETE api/Patient/2
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var patient = _patientervice.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }

            _patientervice.Delete(patient);
            return NoContent();
        }
    }
}
