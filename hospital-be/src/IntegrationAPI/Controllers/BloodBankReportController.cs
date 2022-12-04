using IntegrationAPI.Communications.Pdf;
using IntegrationLibrary.BloodReport.Model;
using IntegrationLibrary.BloodReport.Service;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBankReportController : ControllerBase
    {
        private readonly IBbReportService _service;

        public BloodBankReportController(IBbReportService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult Create(string bloodBankId)
        {
            ReportPathTransporter retVal =  _service.Create(bloodBankId);
            sendPdf(retVal.ReportPath);
            return Ok(retVal);
        }
        private string sendPdf(string path)
        {
            return PdfSender.SendPdf(IntegrationLibrary.Settings.PdfSenderResources.isaUrl, path);
        }
    }
}
