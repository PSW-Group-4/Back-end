using System;

namespace HospitalAPI.Dtos.AdmissionHistory
{
    public class AdmissionHistoryRequestDto
    {
        public Guid AdmissionId { get; set; }
        public DateTime DischargeDate { get; set; }
        public string DischargeReason { get; set; }
    }
}
