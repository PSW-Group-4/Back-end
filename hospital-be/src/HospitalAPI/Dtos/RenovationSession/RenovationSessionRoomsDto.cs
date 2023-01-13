using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Renovation.Model;

namespace HospitalAPI.Dtos.RenovationSession
{
    public class RenovationSessionRoomsDto
    {
        public Guid AggregateId {get; set;}
        public IEnumerable<RoomRenovationPlanDto> roomPlans {get; set;}
    }
}