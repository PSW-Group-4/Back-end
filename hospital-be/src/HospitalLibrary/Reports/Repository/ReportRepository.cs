using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Medicines.Model;
using HospitalLibrary.Reports.Model;
using HospitalLibrary.Reports.Model;
using HospitalLibrary.Settings;
using HospitalLibrary.Symptoms.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Reports.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly HospitalDbContext _context;
        public ReportRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Report> GetAll()
        {
            return _context.Reports.ToList();
        }

        public Report GetById(Guid id)
        {
            var result = _context.Reports.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public Report Create(Report report)
        {
            List<Symptom> symptoms = new List<Symptom>(report.Symptoms);
            report.Symptoms.Clear();
            foreach (Symptom symptom in symptoms)
            {
                report.AddSymptom(_context.Symptoms.SingleOrDefault(s => s.Id.Equals(symptom.Id)));
            }
            List<Prescription> prescriptions = new List<Prescription>(report.Prescriptions);
            report.Prescriptions.Clear();

            foreach (Prescription prescription in prescriptions)
            {
                List<Medicine> medicines = new List<Medicine>(prescription.Medicines);
                prescription.Medicines.Clear();
                foreach (Medicine medicine in medicines)
                {
                    prescription.AddMedicine(_context.Medicines.SingleOrDefault(m => m.Id.Equals(medicine.Id)));
                }
                report.AddPrescription(prescription);
            }

            _context.Reports.Add(report);
            _context.SaveChanges();
            return report;
        }
        public Report Update(Report report)
        {
            var updatingReport = _context.Reports.SingleOrDefault(r => r.Id == report.Id);
            if (updatingReport == null)
            {
                throw new NotFoundException();
            }

            updatingReport.Update(report);

            _context.SaveChanges();
            return updatingReport;
        }

        public void Delete(Guid reportId)
        {
            var report = GetById(reportId);
            _context.Reports.Remove(report);
            _context.SaveChanges();
        }

        public Report GetByMedicalAppointmentId(Guid id)
        {
            Report report = _context.Reports.Where(r => r.MedicalAppointmentId == id).FirstOrDefault();
            if (report == null)
            {
                throw new NotFoundException();
            }
            return report;
        }

        public List<Report> GetBySymptom(String sipmtom)
        {
            List<Report> reportList = new List<Report>();
            foreach(var report in GetAll())
            {
                foreach(var s in report.Symptoms)
                {
                    if (s.Name.ToLower().Contains(sipmtom.ToLower())){
                        reportList.Add(report);
                    }
                }
            }

            return reportList;
        }

        public List<Report> GetByPrescription(String prescription)
        {
            List<Report> reportList = new List<Report>();
            foreach(var report in GetAll())
            {
                foreach(var p in report.Prescriptions)
                {
                    foreach(var medicine in p.Medicines)
                    {
                        if (medicine.Name.ToLower().Contains(prescription.ToLower()))
                        {
                            reportList.Add(report);
                        }
                    }
                }
            }
            return reportList;
        }

        public List<Report> GetByPatientName(String name)
        {
            List<Report> reportList = new List<Report>();
            foreach(var report in GetAll())
            {
                foreach(var medicalAppointment in _context.MedicalAppointments.ToList())
                {
                    if(report.MedicalAppointmentId == medicalAppointment.Id)
                    {
                        foreach(var patient in _context.Patients)
                        {
                            if(patient.Id == medicalAppointment.PatientId)
                            {
                                if (patient.Name.ToLower().Contains(name.ToLower())){
                                    reportList.Add(report);
                                }
                            }
                        }
                    }
                }
            }
            return reportList;
        }

        public List<Report> GetByPatientSurname(String name)
        {
            List<Report> reportList = new List<Report>();
            foreach (var report in GetAll())
            {
                foreach (var medicalAppointment in _context.MedicalAppointments.ToList())
                {
                    if (report.MedicalAppointmentId == medicalAppointment.Id)
                    {
                        foreach (var patient in _context.Patients)
                        {
                            if (patient.Id == medicalAppointment.PatientId)
                            {
                                if (patient.Surname.ToLower().Contains(name.ToLower()))
                                {
                                    reportList.Add(report);
                                }
                            }
                        }
                    }
                }
            }
            return reportList;
        }
        

        public List<Report> BasicSearch(String search)
        {
            string[] words = search.Split(' ');
            List<Report> reportList = new List<Report>();
            foreach (var word in words)
            {
                var getByName = GetByPatientName(word);
                var getBySurname = GetByPatientSurname(word);
                var getByPrescription = GetByPrescription(word);
                var getBySymptom = GetBySymptom(word);

                if(getByName != null)
                {
                    foreach (var report in getByName)
                    {
                        if (!reportList.Contains(report))
                            reportList.Add(report);
                    }
                }
                if (getBySurname != null)
                {
                    foreach (var report in getBySurname)
                    {
                        if (!reportList.Contains(report))
                            reportList.Add(report);
                    }
                }
                if (getByPrescription != null)
                {
                    foreach (var report in getByPrescription)
                    {
                        if (!reportList.Contains(report))
                            reportList.Add(report);
                    }
                }
                if (getBySymptom != null)
                {
                    foreach (var report in getBySymptom)
                    {
                        if (!reportList.Contains(report))
                            reportList.Add(report);
                    }
                }

            }
            return reportList;
        }

        public List<Report> AdvancedSearch(String search)
        {

            string[] words = search.Split(' ');
            
            List<Report> reportList = new List<Report>();
            List<Report> result = new List<Report>();
            reportList = BasicSearch(words[0]);
            if (words.Count() == 1)
            {
                return reportList;
            }
            foreach (string word in words.Skip(1))
            {
                result.Clear();
                bool add = false;
                var reports = BasicSearch(word);
                if(reports.Count == 0)
                {
                    result = new List<Report>();
                    return result;
                }
                
                foreach(var report in reports)
                {
                    foreach(var allReports in reportList)
                    {
                        if(report.Id == allReports.Id)
                        {
                            add = true;
                            if(!result.Contains(report))
                            result.Add(report);
                        }
                    }
                }
                if(add == false)
                {
                    result = new List<Report>();
                    return result;
                }
            }


            return result;
        }
    }
}
