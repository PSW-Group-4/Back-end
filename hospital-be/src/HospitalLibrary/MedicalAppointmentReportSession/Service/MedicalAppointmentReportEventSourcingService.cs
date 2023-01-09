using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Doctors.Repository;
using HospitalLibrary.MedicalAppointmentReportSession.Model.Events;
using HospitalLibrary.MedicalAppointmentReportSession.Repository;
using HospitalLibrary.Medicines.Model;
using HospitalLibrary.Medicines.Repository;
using HospitalLibrary.Patients.Repository;
using HospitalLibrary.Symptoms.Model;
using HospitalLibrary.Symptoms.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.MedicalAppointmentReportSession.Service
{
    public class MedicalAppointmentReportEventSourcingService : IMedicalAppointmentReportEventSourcingService
    {
        private readonly IMedicalAppointmentReportSessionRepository _medAppReportSessionRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly ISymptomRepository _symptomRepository;
        private readonly IMedicineRepository _medicineRepository;

        public MedicalAppointmentReportEventSourcingService(IMedicalAppointmentReportSessionRepository medAppReportSessionRepository, IDoctorRepository doctorRepository, ISymptomRepository symptomRepository, IMedicineRepository medicineRepository)
        {
            _medAppReportSessionRepository = medAppReportSessionRepository;
            _doctorRepository = doctorRepository;
            _symptomRepository = symptomRepository;
            _medicineRepository = medicineRepository;
        }

        public Guid StartScheduling(Guid doctorId, DateTime occurenceTime)
        {
            MedicalAppointmentReportSession session =
                new MedicalAppointmentReportSession(_medAppReportSessionRepository);

            Doctor doctor = _doctorRepository.GetById(doctorId);

            session.Causes(new StartedScheduling(session.Id, occurenceTime, doctor));
            return session.Id;
        }

        public void ChooseSymptom(Guid aggregateId, int numberOfSymptoms, DateTime occurenceTime)
        {
            MedicalAppointmentReportSession session = _medAppReportSessionRepository.GetById(aggregateId);
            session.Causes(new ChosenSymptom(aggregateId, occurenceTime, numberOfSymptoms));
        }


        public void ChooseReportText(Guid aggregateId, string reportText, DateTime occurenceTime)
        {
            MedicalAppointmentReportSession session = _medAppReportSessionRepository.GetById(aggregateId);
            session.Causes(new ChosenReportText(aggregateId, occurenceTime, reportText));
        }

        public void ChooseMedicine(Guid aggregateId, int numberOfMedicines, DateTime occurenceTime)
        {
            MedicalAppointmentReportSession session = _medAppReportSessionRepository.GetById(aggregateId);
            session.Causes(new ChosenMedicine(aggregateId, occurenceTime, numberOfMedicines));
        }


        public void FinishScheduling(Guid aggregateId, DateTime time, DateTime occurenceTime)
        {
            MedicalAppointmentReportSession session = _medAppReportSessionRepository.GetById(aggregateId);
            session.Causes(new FinishedScheduling(aggregateId, occurenceTime, time));
        }

        public void GoBackToSelection(Guid aggregateId, SelectionReport selection, DateTime occurenceTime)
        {
            MedicalAppointmentReportSession session = _medAppReportSessionRepository.GetById(aggregateId);
            session.Causes(new GoneBackToSelection(aggregateId, occurenceTime, selection));
        }


        private List<Symptom> GetSelectedSymptoms(List<Guid> symptoms)
        {
            List<Symptom> Symptoms = new List<Symptom>();
            foreach (var symptom in symptoms)
            {
                Symptoms.Add(_symptomRepository.GetById(symptom));
            }
            return Symptoms;
        }


        private List<Medicine> GetSelectedMedicines(List<Guid> medicines)
        {
            List<Medicine> Medicines = new List<Medicine>();
            foreach (var medicine in medicines)
            {
                Medicines.Add(_medicineRepository.GetById(medicine));
            }
            return Medicines;
        }
    }
}
