using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using HospitalAPI.Dtos.Symptom;
using HospitalLibrary.Symptoms.Model;
using HospitalLibrary.Symptoms.Service;
using AutoMapper;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SymptomController : ControllerBase
    {
        private readonly ISymptomService _symptomService;
        private readonly IMapper _mapper;

        public SymptomController(ISymptomService symptomService, IMapper mapper)
        {
            _symptomService = symptomService;
            _mapper = mapper;
        }

        //GET: api/Symptom
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_symptomService.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] Guid id)
        {
            try
            {
                var patient = _symptomService.GetById(id);
                return Ok(patient);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
        //POST: api/Symptom
        [HttpPost]
        public ActionResult Create([FromBody] SymptomRequestDto symptomRequestDto)
        {
            var symptom = _mapper.Map<Symptom>(symptomRequestDto);
            _symptomService.Create(symptom);
            return CreatedAtAction("GetById", new { id = symptom.Id }, symptom);
        }

        //DELETE: api/Symptom/222
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                _symptomService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
