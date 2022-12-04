using System;
using AutoMapper;
using HospitalAPI.Dtos.AdmissionHistory;
using HospitalLibrary.AdmissionHistories.Model;
using HospitalLibrary.AdmissionHistories.Service;
using HospitalLibrary.Admissions.Service;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionHistoryController : ControllerBase
    {
        private readonly IAdmissionHistoryService _admissionService;
        private readonly IMapper _mapper;
        private readonly IAdmissionService service;

        public AdmissionHistoryController(IAdmissionHistoryService admissionService, IMapper mapper,
            IAdmissionService service)
        {
            _admissionService = admissionService;
            _mapper = mapper;
            this.service = service;
        }

        // GET: api/Admission
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_admissionService.GetAll());
        }

        // GET: api/Admission/1
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] Guid id)
        {
            try
            {
                var admission = _admissionService.GetById(id);
                return Ok(admission);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        // POST api/Admission
        [HttpPost]
        public ActionResult Create([FromBody] AdmissionHistoryRequestDto admissionDto)
        {
            try
            {
                if (service.GetById(admissionDto.AdmissionId) == null)
                    return null;
                var admission = _mapper.Map<AdmissionHistory>(admissionDto);
                _admissionService.Create(admission);
                return CreatedAtAction("GetById", new { id = admission.Id }, admission);
            }
            catch (NotFoundException)
            {
                return null;
            }
        }
    }
}