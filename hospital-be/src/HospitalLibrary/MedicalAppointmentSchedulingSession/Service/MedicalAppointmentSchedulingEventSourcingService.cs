using System;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Doctors.Repository;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Events;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Repository;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Repository;

namespace HospitalLibrary.MedicalAppointmentSchedulingSession.Service
{
    public class MedicalAppointmentSchedulingEventSourcingService : IMedicalAppointmentSchedulingEventSourcingService
    {

        private readonly IMedicalAppointmentSchedulingSessionRepository _medAppSchedSessionRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;

        public MedicalAppointmentSchedulingEventSourcingService(IMedicalAppointmentSchedulingSessionRepository medAppSchedSessionRepository,
            IPatientRepository patientRepository, IDoctorRepository doctorRepository)
        {
            _medAppSchedSessionRepository = medAppSchedSessionRepository;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }
        
        public Guid StartScheduling(Guid patientId, DateTime occurenceTime)
        {
            MedicalAppointmentSchedulingSession session =
                new MedicalAppointmentSchedulingSession(_medAppSchedSessionRepository);
            
            Patient patient = _patientRepository.GetById(patientId);
            
            session.Causes(new StartedScheduling(session.Id, occurenceTime, patient));
            return session.Id;
        }

        public void ChooseDate(Guid aggregateId, DateTime date, DateTime occurenceTime)
        {
            MedicalAppointmentSchedulingSession session = _medAppSchedSessionRepository.GetById(aggregateId);
            session.Causes(new ChosenDate(aggregateId, occurenceTime, date));
        }

        public void ChooseSpeciality(Guid aggregateId, string speciality, DateTime occurenceTime)
        {
            MedicalAppointmentSchedulingSession session = _medAppSchedSessionRepository.GetById(aggregateId);
            session.Causes(new ChosenSpeciality(aggregateId, occurenceTime, speciality));
        }

        public void ChooseDoctor(Guid aggregateId, Guid doctorId, DateTime occurenceTime)
        {
            MedicalAppointmentSchedulingSession session = _medAppSchedSessionRepository.GetById(aggregateId);
            Doctor doctor = _doctorRepository.GetById(doctorId);
            session.Causes(new ChosenDoctor(aggregateId, occurenceTime, doctor));
        }

        public void FinishScheduling(Guid aggregateId, DateTime time, DateTime occurenceTime)
        {
            MedicalAppointmentSchedulingSession session = _medAppSchedSessionRepository.GetById(aggregateId);
            session.Causes(new FinishedScheduling(aggregateId, occurenceTime, time));
        }

        public void GoBackToSelection(Guid aggregateId, Selection selection, DateTime occurenceTime)
        {
            MedicalAppointmentSchedulingSession session = _medAppSchedSessionRepository.GetById(aggregateId);
            session.Causes(new GoneBackToSelection(aggregateId, occurenceTime, selection));
        }
    }
}