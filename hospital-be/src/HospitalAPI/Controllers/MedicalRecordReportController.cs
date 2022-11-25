using HospitalLibrary.AdmissionHistories.Model;
using HospitalLibrary.AdmissionHistories.Service;
using HospitalLibrary.Admissions.Service;
using HospitalLibrary.MedicalReport.Services;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalRecordReportController : ControllerBase
    {
        private readonly IMedicalRecordService medicalRecordService;
        private readonly IAdmissionHistoryService admissionHistoryService;

        public MedicalRecordReportController(IMedicalRecordService medicalRecordService, IAdmissionHistoryService admissionHistoryService)
        {
            this.medicalRecordService = medicalRecordService;
            this.admissionHistoryService = admissionHistoryService;
        }

        [HttpGet("{id}")]
        public ActionResult GenerateSeveralPdf([FromRoute] Guid id)
        {
            try
            {
                AdmissionHistory admissionHistory = admissionHistoryService.GetById(id);
                return File(medicalRecordService.GeneratePdf(admissionHistory), "application/pdf", "medicalReport.pdf");
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
