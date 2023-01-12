using IntegrationLibrary.TenderApplications.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.TenderReport.Service
{
    public class TenderReportService : ITenderReportService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        List<TenderApplication> list = new List<TenderApplication>();


        public TenderReportService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public List<TenderApplication> GetAll()
        {
            string apiUrl = "http://localhost:45488/api/TenderApplication";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                List<TenderApplication> tenders = JsonConvert.DeserializeObject<List<TenderApplication>>(json);
                return tenders;
            }
            return null;
        }

        public float getBloodAmountByBloodType(string bloodtype)
        {
            float price = 0F;
            foreach (TenderApplication t in GetAll())
            {
                String[] s = t.Tender.Blood.ToString().Split(",");
                if (s[0] == bloodtype)
                    price += float.Parse(s[1]);
            }
            return price;
        }

        public String getTenderPriceByMonth(String month, String year)
        {
            float price = 0F;
            foreach (TenderApplication t in GetAll())
            {
                if (t.CreatedDate.Month.ToString() == month && t.CreatedDate.Year.ToString() == year)
                    price += float.Parse(t.Price.ToString());
            }
            return price.ToString();
        }
    }
}
