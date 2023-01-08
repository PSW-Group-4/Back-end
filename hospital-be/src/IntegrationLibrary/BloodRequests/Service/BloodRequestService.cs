using IntegrationLibrary.BloodRequests.Repository;
using IntegrationLibrary.BloodRequests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.UrgentBloodRequestReports.Model;
using IntegrationLibrary.Common;

namespace IntegrationLibrary.BloodRequests.Service
{
    public class BloodRequestService : IBloodRequestService
    {
        private readonly IBloodRequestRepository _repository;
        public BloodRequestService(IBloodRequestRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<BloodRequest> GetAll()
        {
            return _repository.GetAll();
        }

        public BloodRequest GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<BloodRequest> GetUnapproved()
        {
            return _repository.GetUnapproved();
        }
        
        public BloodRequest Create(BloodRequest bloodRequest)
        {
            return _repository.Create(bloodRequest);
        }
        
        public BloodRequest Update(BloodRequest bloodRequest)
        {
            return _repository.Update(bloodRequest);
        }

        public IEnumerable<BloodRequest> GetAllUrgentApprovedNotSent()
        {
            return _repository.GetAllUrgentApprovedNotSent();
        }
        public List<BloodRequest> GetUrgentRequestsInDateRange(DateTime begining, DateTime ending) {
            IEnumerable<BloodRequest> requests = _repository.GetUrgentApprovedSent();
            List<BloodRequest> requestsInRange = new List<BloodRequest>();
            foreach (BloodRequest request in requests) {
                if (request.SendOnDate >= begining) {
                    if (request.SendOnDate <= ending) {
                        requestsInRange.Add(request);
                    }
                }
            }
            return requestsInRange;
        }
        public List<Blood> FillBlood() {
            List<Blood> blood = new List<Blood>();
            blood.Add(new Blood(new BloodType(BloodGroup.O, RhFactor.NEGATIVE),0));
            blood.Add(new Blood(new BloodType(BloodGroup.O, RhFactor.POSITIVE), 0));
            blood.Add(new Blood(new BloodType(BloodGroup.A, RhFactor.NEGATIVE), 0));
            blood.Add(new Blood(new BloodType(BloodGroup.A, RhFactor.POSITIVE), 0));
            blood.Add(new Blood(new BloodType(BloodGroup.B, RhFactor.NEGATIVE), 0));
            blood.Add(new Blood(new BloodType(BloodGroup.B, RhFactor.POSITIVE), 0));
            blood.Add(new Blood(new BloodType(BloodGroup.AB, RhFactor.NEGATIVE), 0));
            blood.Add(new Blood(new BloodType(BloodGroup.AB, RhFactor.POSITIVE), 0));
            return blood;
        }
        public List<UrgentBloodRequestReport> FillTheReport(IEnumerable<BloodBank> banks, List<BloodRequest> requests) {
            List<UrgentBloodRequestReport> report = new List<UrgentBloodRequestReport>();
            List<Blood> bloodAfterCalculation = new List<Blood>();
            foreach (BloodBank bank in banks)
            {
                List<Blood> allBlood = FillBlood();
                foreach (Blood blood in allBlood)
                {
                   double bloodAmount = 0;
                    foreach (BloodRequest request in requests)
                    {
                        if (request.BloodBank.Equals(bank))
                        {
                           if (blood.BloodType.Equals(request.Blood.BloodType))
                           {
                                bloodAmount+=request.Blood.Amount;
                           }
                        }
                    }
                    bloodAfterCalculation.Add(new Blood(blood.BloodType, bloodAmount));
                }
                report.Add(new UrgentBloodRequestReport(bank, bloodAfterCalculation));
            }
            return report;
        }
        public void GenerateUrgentRequestReportForDateRange(DateTime begining, DateTime ending, IEnumerable<BloodBank> banks)
        {
            List<BloodRequest> requests = GetUrgentRequestsInDateRange(begining, ending);
            List<UrgentBloodRequestReport> report = FillTheReport(banks, requests);
        }
    }
}
