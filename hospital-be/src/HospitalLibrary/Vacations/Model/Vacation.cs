using HospitalLibrary.Doctors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Vacations.Model
{
    
    public class Vacation
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public String Reason { get; set; }
        public bool Urgent { get; set; }
        public VacationStatus VacationStatus { get; set; }
        public String DeniedRequestReason { get; set; }

        public void Update(Vacation vacation)
        {
            Reason = vacation.Reason;
            VacationStatus = vacation.VacationStatus;
            DeniedRequestReason = vacation.DeniedRequestReason;
        }
    }
    public enum VacationStatus
    {
        Waiting_For_Approval,
        Approved,
        Denied
    }
}
