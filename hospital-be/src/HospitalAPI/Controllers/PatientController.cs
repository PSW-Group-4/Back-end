using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using HospitalAPI.Dtos.Patient;
using HospitalLibrary;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Users.Model;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public PatientController(IPatientService patientService, IMapper mapper, IJwtService jwtService)
        {
            _patientService = patientService;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        // GET: api/Patient
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_patientService.GetAll());
        }

        // GET: api/Patient/info
        [HttpGet("info")]
        [Authorize(Roles = "Patient")]
        public ActionResult GetInfoForLoggedinPatient()
        {
            User user = _jwtService.GetCurrentUser(HttpContext.User);
            Patient patient = _patientService.GetById(user.PersonId);
            return Ok(patient);
        }

        // GET api/Patient/2
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] Guid id)
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
        public ActionResult Create([FromBody]PatientRequestDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            _patientService.Create(patient);
            return CreatedAtAction("GetById", new { id = patient.Id }, patient);
        }

        // PUT api/Patient/2
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute]Guid id,[FromBody] PatientRequestDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            patient.Id = id;
            
            try
            {
                var result = _patientService.Update(patient);
                return Ok(result);
            }
            catch(NotFoundException)
            {
                return NotFound();
            }
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


        // GET api/Patient/patientsByAgeGroup
        [HttpGet("patientsByAgeGroup")]
        public ActionResult PatientsByAgeGroup()
        {
            return Ok(_patientService.PatientsByAgeGroup());
        }


        // GET api/Patient/patientsByGender
        [HttpGet("patientsByGender")]
        public ActionResult PatientsByGender()
        {
            return Ok(_patientService.PatientsByGender());
        }

        // GET api/Patient/doctorsPatientsByAgeGroup/2
        [HttpGet("doctorsPatientsByAgeGroup/{DoctorId}")]
        public ActionResult DoctorsPatientsByAgeGroup([FromRoute] Guid DoctorId)
        {
            return Ok(_patientService.DoctorsPatientsByAgeGroup(DoctorId));
        }

    }
}
