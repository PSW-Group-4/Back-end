using AutoMapper;
using HospitalAPI.Dtos.Patient;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Service;
using HospitalLibrary.Users.Model;
using HospitalLibrary.Users.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;

        public PatientController(IPatientService patientService, IMapper mapper, IJwtService jwtService, IUserService userService)
        {
            _patientService = patientService;
            _mapper = mapper;
            _jwtService = jwtService;
            _userService = userService;
        }

        // GET: api/Patient
        [HttpGet]
        public ActionResult GetAll()
        {
            var patients = _patientService.GetAll();
            return Ok(_mapper.Map<IEnumerable<PatientGetResponseDto>>(patients));
        }

        // GET: api/Patient/info
        [HttpGet("info")]
        [Authorize(Roles = "Patient")]
        public ActionResult GetInfoForLoggedinPatient()
        {
            User user = _jwtService.GetCurrentUser(HttpContext.User);
            if (user.PersonId != null)
            {
                Patient patient = _patientService.GetById((Guid)user.PersonId);
                return Ok(_mapper.Map<PatientInfoDto>(patient));
            }

            return BadRequest("This user is not a patient");
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
        public ActionResult Create([FromBody] PatientRequestDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            _patientService.Create(patient);
            return CreatedAtAction("GetById", new { id = patient.Id }, patient);
        }

   

        // DELETE api/Patient/2
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
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


        // WILL BE DELETED LATER, JUST TESTING UNTIL APPOINTMENT CANCELLATION IS FINISHED
        [HttpGet("cancel-appointment-test/{PatientId}")]
        public ActionResult CancelAppointmentTest([FromRoute] Guid PatientId)
        {
            try
            {
                _userService.AddSuspiciousActivityToUser(PatientId, new SuspiciousActivity("Appointment cancellation"));
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound("User that is connected to this patient is not found");
            }
        }


    }
}
