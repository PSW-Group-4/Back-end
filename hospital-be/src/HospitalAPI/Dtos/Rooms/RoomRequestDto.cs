﻿using System;

namespace HospitalAPI.Controllers.Dtos.Rooms
{
    public class RoomRequestDto
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public int Number { get; set; }
    }
}
