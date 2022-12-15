using IntegrationAPI.Dtos.BloodProducts;
using IntegrationLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Dtos.BloodRequests
{
    public class BloodRequestEditDto
    {
        public Guid Id { get; set; }
        public String Reason { get; set; }
        public Boolean IsApproved { get; set; }
        public String RejectionComment { get; set; }
        public String ManagerId { get; set; }
    }
}
