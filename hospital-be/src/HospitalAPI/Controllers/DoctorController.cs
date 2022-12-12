using System;
using System.Collections.Generic;
using AutoMapper;
using HospitalAPI.Dtos.Person;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorService doctorService, IMapper mapper, IJwtService jwtService)
        {
            _doctorService = doctorService;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        // GET: api/Doctor
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_doctorService.GetAll());
        }

        //Vraca samo puno ime svih doktora
        [Authorize(Roles = "Patient")]
        [HttpGet("basicInfo")]
        public ActionResult GetAllBasicInfo()
        {
            return Ok(_mapper.Map<IEnumerable<PersonFullnameDto>>(_doctorService.GetAll()));
        }

        // GET api/Doctor/2
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] Guid id)
        {
            try
            {
                var doctor = _doctorService.GetById(id);
                return Ok(doctor);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("loggedDoctor")]
        public ActionResult GetLoggedDoctor()
        {
            try
            {
                var DoctorId = (Guid)_jwtService.GetCurrentUser(HttpContext.User).PersonId;
                var doctor = _doctorService.GetById(DoctorId);
                return Ok(doctor);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [Authorize(Roles = "Patient,Doctor")]
        [HttpGet("specialties")]
        public ActionResult GetAllSpecialties()
        {
            return Ok(_doctorService.GetAllSpecialties());
        }
        
        [Authorize(Roles = "Patient")]
        [HttpGet("specialties/{specialty}")]
        public ActionResult GetDoctorsWithSpecialty([FromRoute] string specialty)
        {
            var doctors = _doctorService.GetDoctorsWithSpecialty(specialty);
            return Ok(_mapper.Map<IEnumerable<PersonFullnameDto>>(doctors));
        }

        // GET api/Doctor/doctorsWithLeastPatients
        [HttpGet("doctorsWithLeastPatients")]
        public ActionResult DoctorsWithLeastPatients()
        {
            return Ok(_doctorService.DoctorsWithLeastPatients());
        }
    }
}