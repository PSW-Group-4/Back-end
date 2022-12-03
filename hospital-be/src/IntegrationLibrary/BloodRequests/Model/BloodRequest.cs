using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodRequests.Model
{
    [Table("blood_requests")]
    public class BloodRequest
    {
        public Guid Id { get; set; }
        public String DoctorId { get; set; }
        public String Reasons { get; set; }
        public virtual Blood Blood { get; set; }
        public Boolean IsApproved { get; set; }
        public String RejectionComment { get; set; }
        public String ManagerId { get; set; }
        public DateTime SendOnDate { get; set; }
        public bool IsUrgent { get; set; }
        public BloodRequestStatus Status { get; set; }
        public virtual BloodBank BloodBank { get; set; }
    }

    public enum BloodRequestStatus
    {
        PENDING_RESPONSE,
        APPROVED_BY_BANK,
        REJECTED_BY_BANK,
        FAILED,
        FULFILLED
    }
}
