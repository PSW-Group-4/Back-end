using AutoMapper;
using HospitalAPI.Dtos.Feedback;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Feedbacks.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

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
                Guid DoctorId = (Guid)_jwtService.GetCurrentUser(HttpContext.User).PersonId;
                var doctor = _doctorService.GetById(DoctorId);
                return Ok(doctor);
            }
            catch (NotFoundException)
            {
                return NotFound();            }

            
        }


        // GET api/Doctor/doctorsWithLeastPatients
        [HttpGet("doctorsWithLeastPatients")]
        public ActionResult DoctorsWithLeastPatients()
        {
            return Ok(_doctorService.DoctorsWithLeastPatients());
        }

    }
}
