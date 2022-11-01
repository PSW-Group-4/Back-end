using HospitalAPI.Controllers.Dtos.Rooms;
using HospitalLibrary.RoomsAndEqipment.Model;
using System;

namespace HospitalAPI.Controllers.Dtos.Doctor
{
    public class DoctorRequestDto : PersonRequestDto
    {
        public string LicenceNum { get; set; }
        public string Speciality { get; set; }
        public string WorkingTimeStart { get; set; }
        public string WorkingTimeEnd { get; set; }
        public Guid RoomId { get; set; }
    }
}
