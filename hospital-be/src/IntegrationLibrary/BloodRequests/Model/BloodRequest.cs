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
        public string DoctorId { get; set; }
        public string Reasons { get; set; }
        public virtual Blood Blood { get; set; }
        public bool IsApproved { get; set; }
        public string RejectionComment { get; set; }
        public string ManagerId { get; set; }
        public DateTime SendOnDate { get; set; }
        public bool IsUrgent { get; set; }
        public BloodRequestStatus Status { get; set; }
        public virtual BloodBank BloodBank { get; set; }
    }

    public enum BloodRequestStatus
    {
        PENDING_APPROVAL,
        REJECTED_BY_MANAGER,
        APPROVED_BY_MANAGER,
        TO_BE_SENT,
        PENDING_RESPONSE,
        APPROVED_BY_BANK,
        REJECTED_BY_BANK,
        FAILED,
        FULFILLED
    }
}
