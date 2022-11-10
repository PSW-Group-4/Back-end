using System;

namespace HospitalAPI.Dtos.Admission
{
    public class AdmissionRequestDto
    {
        public Guid RoomId { get; set; }
        public Guid PatientId { get; set; }
        public string Reason { get; set; }
        public DateTime arrivalDate { get; set; }
    }
}
