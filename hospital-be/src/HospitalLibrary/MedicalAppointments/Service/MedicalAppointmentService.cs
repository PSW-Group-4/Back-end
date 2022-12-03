using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.Doctors.Service;
using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Service;

namespace HospitalLibrary.Appointments.Service
{
    public class MedicalAppointmentService : IMedicalAppointmentService
    {
        private readonly IMedicalAppointmentRepository _medicalAppointmentRepository;
        private readonly IDoctorService _doctorService;

        public MedicalAppointmentService(IMedicalAppointmentRepository medicalAppointmentRepository, IDoctorService doctorService)
        {
            _medicalAppointmentRepository = medicalAppointmentRepository;
            _doctorService = doctorService;
        }

        public IEnumerable<MedicalAppointment> GetAll()
        {
            MedicalAppointmentService appointmentService = new MedicalAppointmentService(_medicalAppointmentRepository, _doctorService);
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

    }
}
