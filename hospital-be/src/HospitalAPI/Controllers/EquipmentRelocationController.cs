using System;
using AutoMapper;
using HospitalLibrary.EquipmentRelocation.DTO;
using HospitalLibrary.EquipmentRelocation.Service;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentRelocationController : ControllerBase
    {
        private readonly IEquipmentRelocationService _equipmentRelocationService;
        private readonly IMapper _mapper;

        public EquipmentRelocationController(IEquipmentRelocationService service, IMapper mapper)
        {
            _equipmentRelocationService = service;
            _mapper = mapper;
        }


        [HttpGet("Recommend/{relocationStart}/{duration}/{sourceId}/{targetId}")]
        [Authorize(Roles = "Manager")]
        public ActionResult Recommend([FromRoute] string relocationStart, [FromRoute] int duration,
            [FromRoute] string sourceId, [FromRoute] string targetId)
        {
            try
            {
                var dateTime = DateTime.Parse(relocationStart);
                var equipmentRelocation =
                    new EquipmentRelocationDTO(dateTime, duration, Guid.Parse(sourceId), Guid.Parse(targetId));

                var termins = _equipmentRelocationService.RecommendRelocationStart(equipmentRelocation);
                return Ok(termins);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}