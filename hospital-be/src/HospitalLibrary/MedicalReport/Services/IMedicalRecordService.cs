using HospitalLibrary.AdmissionHistories.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.MedicalReport.Services
{
    public interface IMedicalRecordService
    {
        public byte[] GeneratePdf(AdmissionHistory admissionHistory);
    }
}
