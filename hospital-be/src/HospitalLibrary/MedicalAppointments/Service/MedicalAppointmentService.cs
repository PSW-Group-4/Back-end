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
using HospitalLibrary.Exceptions;
using Microsoft.EntityFrameworkCore;

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

        public void Cancel(Guid appointmentId, Guid patientId)
        {
            var appointment = GetById(appointmentId);
            if(appointment.PatientId != patientId)
            {
                throw new CanNotCancelAppointmentException("Can not cancel appointment that is not your own");
            }
            if (appointment.IsCanceled)
            {
                throw new AlreadyCanceledException();
            }
            if (appointment.IsDone)
            {
                throw new CanNotCancelAppointmentException("Appointment is already done");
            }

            if (DateTime.Now.AddHours(24) >= appointment.DateRange.StartTime)
            {
                throw new CanNotCancelAppointmentException("Can not cancel less then 24h");
            }

            appointment.CancelAppointment();
            _medicalAppointmentRepository.Update(appointment);
        }

        public IEnumerable<MedicalAppointment> GetDoneByPatient(Guid patientId)
        {
            return _medicalAppointmentRepository.GetDoneByPatient(patientId);
        }

        public IEnumerable<MedicalAppointment> GetCanceledByPatient(Guid patientId)
        {
            return _medicalAppointmentRepository.GetCacneledByPatient(patientId);
        }

        public IEnumerable<MedicalAppointment> GetFutureByPatient(Guid patientId)
        {
            return _medicalAppointmentRepository.GetFutureByPatient(patientId);
        }
    }
}
