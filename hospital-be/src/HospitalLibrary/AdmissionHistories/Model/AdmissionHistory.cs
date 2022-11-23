using HospitalLibrary.Admissions.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.AdmissionHistories.Model
{
    public class AdmissionHistory
    {
        public Guid Id { get; set; }
        public Guid AdmissionId { get; set; }
        public virtual Admission Admission { get; set; }
        public DateTime DischargeDate { get; set; }
        public string DischargeReason { get; set; }
    }
}
