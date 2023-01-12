using IntegrationLibrary.TenderApplications.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.TenderReport.Service
{
    public interface ITenderReportService
    {
        public List<TenderApplication> GetAll();
            
        public String getTenderPriceByMonth(String month, String year);

        public float getBloodAmountByBloodType(String bloodtype);
    }
}
