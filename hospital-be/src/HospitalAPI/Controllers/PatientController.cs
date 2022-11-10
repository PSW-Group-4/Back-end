﻿using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using HospitalAPI.Dtos.Patient;
using HospitalLibrary;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public PatientController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

        // GET: api/Patient
        [HttpGet]
        [Authorize(Roles = "Patient")]
        public ActionResult GetAll()
        {
            return Ok(_patientService.GetAll());
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
    }
}
