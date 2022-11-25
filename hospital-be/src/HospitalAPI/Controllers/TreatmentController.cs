using AutoMapper;
using HospitalAPI.Dtos.Appointment;
using HospitalLibrary;
using HospitalLibrary.Admissions.Service;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;
using HospitalAPI.Dtos.Admission;
using System;
using HospitalLibrary.Admissions.Model;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using HospitalAPI.Dtos.Bed;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalAPI.Dtos.Treatment;
using HospitalLibrary.Treatments.Model;
using HospitalLibrary.Treatments.Service;
using HospitalAPI.Dtos.Medicine;
using HospitalLibrary.Medicines.Model;
using System.Security.Cryptography.X509Certificates;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentController : ControllerBase
    {
        private readonly ITreatmentService _treatmentService;
        private readonly IMapper _mapper;
        public TreatmentController(ITreatmentService treatmentService, IMapper mapper)
        {
            _treatmentService = treatmentService;
            _mapper = mapper;
        }
        //GET: api/Treatment
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_treatmentService.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] Guid id)
        {
            try
            {
                var patient = _treatmentService.GetById(id);
                return Ok(patient);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
        //POST: api/Treatment
        [HttpPost]
        public ActionResult Create([FromBody] TreatmentRequestDto treatmentRequestDto)
        {
            var treatment = _mapper.Map<Treatment>(treatmentRequestDto);
            _treatmentService.Create(treatment);
            return CreatedAtAction("GetById", new { id = treatment.Id }, treatment);
        }

        //PUT
        [HttpPut("/TreatmentMedicine/{medicineId}")]
        public ActionResult UpdateMedicine([FromRoute] Guid medicineId, [FromBody] TreatmentUpdateDto treatmentRequestDto)
        {
            var treatment = _mapper.Map<Treatment>(treatmentRequestDto);
            //treatment.MedicineId = medicineId;

            try
            {
                var result = _treatmentService.UpdateMedicine(treatment, medicineId);
                return Ok(result);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
        [HttpPut("/TreatmentBlood/{bloodConsumptionRecordId}")]
        public ActionResult UpdateBloodConsumption([FromRoute] Guid bloodConsumptionRecordId, [FromBody] TreatmentUpdateDto treatmentRequestDto)
        {
            var treatment = _mapper.Map<Treatment>(treatmentRequestDto);
            //treatment.BloodConsumptionRecordId = bloodConsumptionRecordId;

            try
            {
                var result = _treatmentService.UpdateBloodConsuptionRecord(treatment, bloodConsumptionRecordId);
                return Ok(result);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }



        //DELETE: api/Treatment/222
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                _treatmentService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }        

        }
        
    }
}
