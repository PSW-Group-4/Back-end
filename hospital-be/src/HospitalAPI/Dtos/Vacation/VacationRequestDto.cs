using HospitalLibrary.Vacations.Model;
using System;

namespace HospitalAPI.Dtos.Vacation
{
    public class VacationRequestDto
    {
        public Guid DoctorId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public String Reason { get; set; }
        public bool Urgent { get; set; }
        public VacationStatus VacationStatus { get; set; }
        public String DeniedRequestReason { get; set; }
    }
}
