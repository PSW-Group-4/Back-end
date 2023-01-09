using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HospitalLibrary.Renovation.Model;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Authorization;
using HospitalAPI.Dtos.Renovation;
using HospitalAPI.Dtos.RenovationSession;
using HospitalLibrary.RenovationSessionAggregate.Services.Interfaces;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Manager")]
    public class RenovationSessionController : ControllerBase
    {
        private readonly IRenovationSessionService _renovationSessionService;
        private readonly IMapper _mapper;
        
        public RenovationSessionController(IRenovationSessionService renovationSessionService, IMapper mapper)
        {
            _renovationSessionService = renovationSessionService;
            _mapper = mapper;
        }

        [HttpPost("choose-old-rooms")]
        public ActionResult ChooseOldRooms([FromBody] RenovationSessionRoomsDto data)
        {
            List<RoomRenovationPlan> plans = new List<RoomRenovationPlan>();
            foreach(RoomRenovationPlanDto plan in data.roomPlans) {
                plans.Add(new RoomRenovationPlan(Guid.Parse(plan.Id)));
            }
            _renovationSessionService.ChooseOldRooms(data.AggregateId, plans);
            return Ok();
        }

        [HttpPost("choose-specific-time")]
        public ActionResult ChooseSpecificTime([FromBody] RenovationSessionDateDto data)
        {
            _renovationSessionService.ChooseSpecificTime(data.AggregateId, data.Start, data.End);
            return Ok();
        }

        [HttpPost("choose-type")]
        public ActionResult ChooseType([FromBody] RenovationSessionTypeDto data)
        {
            _renovationSessionService.ChooseType(data.AggregateId, Enum.Parse<RenovationAppointment.TypeOfRenovation>(data.Type)); 
            return Ok();
        }

        [HttpPost("create-new-rooms")]
        public ActionResult CreateNewRooms([FromBody] RenovationSessionRoomsDto data)
        {
            List<RoomRenovationPlan> plans = new List<RoomRenovationPlan>();
            foreach(RoomRenovationPlanDto plan in data.roomPlans) {
                plans.Add(new RoomRenovationPlan(plan.Name, plan.Description, plan.Number));
            }
            _renovationSessionService.CreateNewRooms(data.AggregateId, plans);
            return Ok();
        }

        [HttpPost("create-timeframe")]
        public ActionResult CreateTimeframe([FromBody] RenovationSessionDateDto data)
        {
            _renovationSessionService.CreateTimeframe(data.AggregateId, data.Start, data.End);
            return Ok();
        }

        [HttpPost("end-session")]
        public ActionResult EndSession([FromBody] RenovationSessionIdOnlyDto dto)
        {
            _renovationSessionService.EndSession(Guid.Parse(dto.AggregateId.ToString()));
            return Ok();
        }

        [HttpPost("return-to-new-room-creation")]
        public ActionResult ReturnToNewRoomCreation([FromBody] RenovationSessionIdOnlyDto dto)
        {
            _renovationSessionService.ReturnToNewRoomCreation(Guid.Parse(dto.AggregateId.ToString()));
            return Ok();
        }

        [HttpPost("return-to-old-rooms-selection")]
        public ActionResult ReturnToOldRoomsSelection([FromBody] RenovationSessionIdOnlyDto dto)
        {
            _renovationSessionService.ReturnToOldRoomsSelection(Guid.Parse(dto.AggregateId.ToString()));
            return Ok();
        }

        [HttpPost("return-to-specific-time-selection")]
        public ActionResult ReturnToSpecificTimeSelection([FromBody] RenovationSessionIdOnlyDto dto)
        {
            _renovationSessionService.ReturnToSpecificTimeSelection(Guid.Parse(dto.AggregateId.ToString()));
            return Ok();
        }

        [HttpPost("return-to-timeframe-creation")]
        public ActionResult ReturnToTimeframeCreation([FromBody] RenovationSessionIdOnlyDto dto)
        {
            _renovationSessionService.ReturnToTimeframeCreation(Guid.Parse(dto.AggregateId.ToString()));
            return Ok();
        }

        [HttpPost("return-to-type-selection")]
        public ActionResult ReturnToTypeSelection([FromBody] RenovationSessionIdOnlyDto dto)
        {
            _renovationSessionService.ReturnToTypeSelection(Guid.Parse(dto.AggregateId.ToString()));
            return Ok();
        }

        [HttpPost("start-session")]
        public ActionResult StartSession()
        {
            Guid id = _renovationSessionService.StartSession();
            return Ok(id);
        }
        

    }
}