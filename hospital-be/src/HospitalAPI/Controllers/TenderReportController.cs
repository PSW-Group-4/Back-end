using HospitalLibrary.TenderReport.Service;
using IntegrationLibrary.TenderApplications.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderReportController
    {
        ITenderReportService service;

        public TenderReportController(ITenderReportService service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<TenderApplication> GetAll()
        {
            return service.GetAll();
        }

        [HttpGet("{month}/{year}")]
        public string getPriceByMonth(string month, string year)
        {
            return service.getTenderPriceByMonth(month, year);
        }

        [HttpGet("{bloodtype}")]
        public float getPriceByMonth(string bloodtype)
        {
            return service.getBloodAmountByBloodType(bloodtype);
        }
    }
}
