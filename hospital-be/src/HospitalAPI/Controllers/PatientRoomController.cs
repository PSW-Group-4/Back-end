using AutoMapper;
using HospitalAPI.Dtos.MapItem;
using HospitalAPI.Dtos.Rooms;
using HospitalLibrary.BuildingManagmentMap.Model;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Exceptions;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.RoomsAndEqipment.Service.Implementation;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientRoomController : ControllerBase
    {
        private readonly IPatientRoomService _patientRoomService;
        private readonly IMapper _mapper;

        public PatientRoomController(IPatientRoomService patientRoomService, IMapper mapper)
        {
            _patientRoomService = patientRoomService;
            _mapper = mapper;
        }

        // GET: api/PatientRoom
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_patientRoomService.GetAll());
        }
        [HttpGet("/RoomsWithFreeBeds")]
        public ActionResult GetRoomsWithFreeBeds()
        {
            return Ok(_patientRoomService.GetRoomsWithFreeBeds());
        }

        //POST: api/PatientRoom
        [HttpPost]
        public ActionResult Create([FromBody] PatientRoomRequestDto patientRoomRequestDto)
        {
            var room = _mapper.Map<PatientRoom>(patientRoomRequestDto);
            _patientRoomService.Create(room);
            return CreatedAtAction("GetById", new { id = room.Id }, room);
        }

        //DELETE: api/PatientRoom/222
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                _patientRoomService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
