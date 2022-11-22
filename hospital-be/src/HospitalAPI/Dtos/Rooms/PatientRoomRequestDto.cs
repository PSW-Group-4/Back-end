using System.Collections.Generic;
using System;

namespace HospitalAPI.Dtos.Rooms
{
    public class PatientRoomRequestDto : RoomRequestDto
    {
        public List<Guid> BedIds { get; set; }
    }
}
