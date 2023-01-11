using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodRequests.Model;
using IntegrationLibrary.Common;
using IntegrationLibrary.UrgentBloodRequestReports.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodRequests.Service
{
    public interface IBloodRequestService
    {
        public IEnumerable<BloodRequest> GetAll();
        public BloodRequest GetById(Guid id);
        public IEnumerable<BloodRequest> GetUnapproved();
        public BloodRequest Create(BloodRequest bloodRequest);
        public BloodRequest Update(BloodRequest bloodRequest);
        public IEnumerable<BloodRequest> GetAllUrgentApprovedNotSent();
        public string GenerateUrgentRequestReportForDateRange(DateTime begining, DateTime end, IEnumerable<BloodBank> banks);
        public string GenerateHtmlForReport(List<UrgentBloodRequestReport> reportSegments, DateTime begining, DateTime ending);
        public List<UrgentBloodRequestReport> FillTheReport(IEnumerable<BloodBank> banks, List<BloodRequest> requests);
        public List<Blood> FillBlood();
    }
}
