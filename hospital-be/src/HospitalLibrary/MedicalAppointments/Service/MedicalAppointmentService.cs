using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.Doctors.Service;
using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Patients.Service;
using HospitalLibrary.Patients.Model;
using Microsoft.VisualBasic;

namespace HospitalLibrary.Appointments.Service
{
    public class MedicalAppointmentService : IMedicalAppointmentService
    {
        private readonly IMedicalAppointmentRepository _medicalAppointmentRepository;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;

        public MedicalAppointmentService(IMedicalAppointmentRepository medicalAppointmentRepository, IDoctorService doctorService, IPatientService patientService)
        {
            _medicalAppointmentRepository = medicalAppointmentRepository;
            _doctorService = doctorService;
            _patientService = patientService;
        }

        public IEnumerable<MedicalAppointment> GetAll()
        {
            //MedicalAppointmentService appointmentService = new MedicalAppointmentService(_medicalAppointmentRepository, _doctorService);
            //appointmentService.CheckIfAppointmentIsDone();
            return _medicalAppointmentRepository.GetAll();
        }

        public MedicalAppointment GetById(Guid id)
        {
            return _medicalAppointmentRepository.GetById(id);
        }

        public MedicalAppointment Create(MedicalAppointment medicalAppointment)
        {
            return _medicalAppointmentRepository.Create(medicalAppointment);
        }

        public MedicalAppointment Update(MedicalAppointment medicalAppointment)
        {
            return _medicalAppointmentRepository.Update(medicalAppointment);
        }

        public void Delete(Guid appointmentId)
        {
            _medicalAppointmentRepository.Delete(appointmentId);
        }

        public bool IsPatientFree(Guid patientId,DateRange rangeTime)
        {
            IEnumerable<MedicalAppointment> patientAppointments = GetAllPatientAppointments(patientId);
            foreach (MedicalAppointment patientAppointment in patientAppointments)
            {
                if (patientAppointment.DateRange.OverlapsWith(rangeTime))
                {
                    return false;
                }
            }

            return true;
        }

        public IEnumerable<MedicalAppointment> GetAllPatientAppointments(Guid patientId)
        {
            IEnumerable<MedicalAppointment> medicalAppointments = _medicalAppointmentRepository.GetAll();
            List<MedicalAppointment> patientAppointments =  new List<MedicalAppointment>();
            foreach (MedicalAppointment appointment in medicalAppointments)
            {
                if (appointment.PatientId.Equals(patientId)){
                    patientAppointments.Add(appointment);
                }
            }
            return patientAppointments;
        }
    }
}
