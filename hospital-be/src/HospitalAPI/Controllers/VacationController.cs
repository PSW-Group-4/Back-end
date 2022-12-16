using AutoMapper;
using HospitalAPI.Dtos.Vacation;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Vacations.Model;
using HospitalLibrary.Vacations.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationController : ControllerBase
    {
        private readonly IVacationService _vacationtService;
        private readonly IMapper _mapper;

        public VacationController(IVacationService vacationtService, IMapper mapper)
        {
            _vacationtService = vacationtService;
            _mapper = mapper;
        }

        // GET: api/Vacation
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_vacationtService.GetAll());
        }

        [HttpGet("/api/managerGetAll")]
        public ActionResult GetAllManager()
        {
            return Ok(_vacationtService.GetAllManager());
        }

        [HttpGet("/api/pastVacations/{doctorId}")]
        public ActionResult GetAllPastByDoctorId(Guid doctorId)
        {
            return Ok(_vacationtService.GetNumberOfVacationsPerMonth(doctorId));
        }

        // GET api/Vacation/1
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] Guid id)
        {
            try
            {
                var vacation = _vacationtService.GetById(id);
                return Ok(vacation);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // POST api/Vacation
        [HttpPost]
        public ActionResult Create([FromBody] VacationRequestDto vacationDto)
        {
            var vacation = _mapper.Map<Vacation>(vacationDto);

            var thisVacation = _vacationtService.Create(vacation);

            if(thisVacation == null)
            {
                return NotFound();
            }
            return CreatedAtAction("GetById", new { id = vacation.Id }, vacation);
        }

        // PUT api/Vacation/1
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] Guid id, [FromBody] VacationRequestDto vacationDto)
        {
            var vacation = _mapper.Map<Vacation>(vacationDto);
            vacation.Id = id;

            try
            {
                var result = _vacationtService.Update(vacation);
                return Ok(result);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE api/Vacation/1
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                _vacationtService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // GET api/DoctorVacation/CurrentRequests/doctorID
        [HttpGet("{vacationStatus}/{id}")]
        public ActionResult GetDoctorVacationsFromSpecificStatus([FromRoute] VacationStatus vacationStatus, [FromRoute] Guid id)
        {
            try
            {
                var vacation = _vacationtService.GetDoctorVacationsFromSpecificStatus(vacationStatus,id);
                return Ok(vacation);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
