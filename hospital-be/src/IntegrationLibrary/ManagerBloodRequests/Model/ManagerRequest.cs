using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.ManagerBloodRequests.Model
{
    [Table("manager_blood_requests")]
    public class ManagerRequest
    {
        public Guid Id { get; set; }
        public virtual Blood Blood { get; set; }
        public string ManagerId { get; set; }
        public virtual BloodBank BloodBank { get; set; }

        public ManagerRequest()
        {
           Id = Guid.NewGuid();
        }
    }
}
