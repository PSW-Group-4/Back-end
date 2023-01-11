using IntegrationLibrary.BloodRequests.Repository;
using IntegrationLibrary.BloodRequests.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.UrgentBloodRequestReports.Model;
using IntegrationLibrary.Common;
using IntegrationLibrary.Utilities.Converters;
using IntegrationLibrary.BloodBanks.Model;

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
        public List<BloodRequest> GetUrgentRequestsInDateRange(DateTime begining, DateTime ending)
        {
            IEnumerable<BloodRequest> requests = _repository.GetAll();
            List<BloodRequest> requestsInRange = new List<BloodRequest>();
            foreach (BloodRequest request in requests)
            {
                if (request.IsUrgent)
                {
                    if (request.SendOnDate >= begining)
                    {
                        if (request.SendOnDate <= ending)
                        {
                            requestsInRange.Add(request);
                        }
                    }
                }
            }
            return requestsInRange;
        }
        public List<Blood> FillBlood()
        {
            List<Blood> blood = new List<Blood>();
            blood.Add(new Blood(new BloodType(BloodGroup.O, RhFactor.NEGATIVE), 0));
            blood.Add(new Blood(new BloodType(BloodGroup.O, RhFactor.POSITIVE), 0));
            blood.Add(new Blood(new BloodType(BloodGroup.A, RhFactor.NEGATIVE), 0));
            blood.Add(new Blood(new BloodType(BloodGroup.A, RhFactor.POSITIVE), 0));
            blood.Add(new Blood(new BloodType(BloodGroup.B, RhFactor.NEGATIVE), 0));
            blood.Add(new Blood(new BloodType(BloodGroup.B, RhFactor.POSITIVE), 0));
            blood.Add(new Blood(new BloodType(BloodGroup.AB, RhFactor.NEGATIVE), 0));
            blood.Add(new Blood(new BloodType(BloodGroup.AB, RhFactor.POSITIVE), 0));
            return blood;
        }
        public List<UrgentBloodRequestReport> FillTheReport(IEnumerable<BloodBank> banks, List<BloodRequest> requests)
        {
            List<UrgentBloodRequestReport> report = new List<UrgentBloodRequestReport>();
            List<Blood> allBlood = FillBlood();
            foreach (BloodBank bank in banks)
            {
                List<Blood> bloodAfterCalculation = new List<Blood>();
                foreach (Blood blood in allBlood)
                {
                    double bloodAmount = 0;
                    foreach (BloodRequest request in requests)
                    {
                        if (request.BloodBank.Equals(bank))
                        {
                            if (blood.BloodType.Equals(request.Blood.BloodType))
                            {
                                bloodAmount += request.Blood.Amount;
                            }
                        }
                    }
                    bloodAfterCalculation.Add(new Blood(blood.BloodType, bloodAmount));
                }
                report.Add(new UrgentBloodRequestReport(bank, bloodAfterCalculation));
            }
            return report;
        }
        public string GenerateUrgentRequestReportForDateRange(DateTime begining, DateTime ending, IEnumerable<BloodBank> banks)
        {
            List<BloodRequest> requests = GetUrgentRequestsInDateRange(begining, ending);
            List<UrgentBloodRequestReport> report = FillTheReport(banks, requests);
            string html = GenerateHtmlForReport(report, begining, ending);
            return HtmlToPdfConverter.Convert(html, HtmlToPdfConverter.defaultPath, "Urgent blood supply report");
        }
        public string GenerateHtmlForReport(List<UrgentBloodRequestReport> reportSegments, DateTime begining, DateTime ending)
        {
            string html = "<h1>Urgent Blood Supply Report Between {0} And {1}</h1>";
            html = string.Format(html, begining.ToString(), ending.ToString());

            foreach (UrgentBloodRequestReport reportSegment in reportSegments)
            {
                html += Environment.NewLine + "<h2>Bank: " + reportSegment.Bank.Name + "</h2>" +
                Environment.NewLine + "<table>" +
                Environment.NewLine + "\t<tr>" +
                Environment.NewLine + "\t\t<th>Blood type</th>" +
                Environment.NewLine + "\t\t<th>RH Factor</th>" +
                Environment.NewLine + "\t\t<th>Amount (ml)</th>" +
                Environment.NewLine + "\t</tr>" +
                Environment.NewLine;

                foreach (Blood blood in reportSegment.Blood)
                {
                    html += Environment.NewLine + "\t<tr>" +
                        Environment.NewLine + "\t\t<td>" + blood.BloodType.BloodGroup.ToString() + "</td>" +
                        Environment.NewLine + "\t\t<td>" + blood.BloodType.RhFactor.ToString() + "</td>" +
                        Environment.NewLine + "\t\t<td>" + blood.Amount.ToString() + "</td>" +
                        Environment.NewLine + "\t</tr>";
                }
                html += Environment.NewLine + "</table>";
            }
            return html;
        }
    }
}
