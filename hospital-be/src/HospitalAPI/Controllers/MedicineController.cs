using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;
using HospitalAPI.Dtos.Admission;
using System;
using HospitalLibrary.Admissions.Model;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using HospitalAPI.Dtos.Bed;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalAPI.Dtos.Medicine;
using HospitalLibrary.Medicines.Model;
using HospitalLibrary.Medicines.Service;
using AutoMapper;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController  : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        private readonly IMapper _mapper;

        public MedicineController(IMedicineService medicineService, IMapper mapper)
        {
            _medicineService = medicineService;
            _mapper = mapper;
        }

        //GET: api/Medicine
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_medicineService.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] Guid id)
        {
            try
            {
                var patient = _medicineService.GetById(id);
                return Ok(patient);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
        //POST: api/Medicine
        [HttpPost]
        public ActionResult Create([FromBody] MedicineRequestDto medicineRequestDto)
        {
            var medicine = _mapper.Map<Medicine>(medicineRequestDto);
            _medicineService.Create(medicine);
            return CreatedAtAction("GetById", new { id = medicine.Id }, medicine);
        }
        //DELETE: api/Medicine/222
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                _medicineService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
