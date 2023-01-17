using HospitalLibrary.Admissions.Model;
using System;

namespace HospitalAPI.Dtos.Admission
{
    public class AdmissionRequestDto
    {
        public Guid RoomId { get; set; }
        public Guid PatientId { get; set; }
        public Reason ReasonText { get; set; }
        public DateTime arrivalDate { get; set; }
    }
}
