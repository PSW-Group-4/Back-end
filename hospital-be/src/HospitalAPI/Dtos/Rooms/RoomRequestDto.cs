using System;

namespace HospitalAPI.Dtos.Rooms
{
    public class RoomRequestDto
    {
        //public Guid Id { get; set; }
        public String Name { get; set; }
        public int Number { get; set; }
        public String Description { get; set; }
    }
}
