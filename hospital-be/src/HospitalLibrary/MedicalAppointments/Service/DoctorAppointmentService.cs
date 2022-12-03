using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.Doctors.Repository;
using System;
using System.Collections.Generic;
using IntegrationLibrary.Utilities;
using MimeKit;

namespace HospitalLibrary.Appointments.Service
{
    public class DoctorAppointmentService : IDoctorAppointmentService
    {
        private readonly IMedicalAppointmentRepository _medicalAppointmentRepository;
        private readonly IDoctorRepository _doctorRepository;

        public DoctorAppointmentService(IMedicalAppointmentRepository medicalAppointmentRepository, IDoctorRepository doctorRepository)
        {
            _medicalAppointmentRepository = medicalAppointmentRepository;
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<MedicalAppointment> GetDoctorAppointments(Guid id)
        {
            IEnumerable<MedicalAppointment> allAppointments = _medicalAppointmentRepository.GetAll();
            List<MedicalAppointment> doctorsAppointments = new List<MedicalAppointment>();

            foreach (MedicalAppointment appointment in allAppointments)
            {
                if (appointment.DoctorId.Equals(id))
                {
                    doctorsAppointments.Add(appointment);
                }
            }
            return doctorsAppointments;
        }

        public IEnumerable<MedicalAppointment> GetDoctorsCurrentAppointments(Guid id)
        {
            IEnumerable<MedicalAppointment> doctorsAppointments = GetDoctorAppointments(id);
            List<MedicalAppointment> doctorsCurrentAppointments = new List<MedicalAppointment>();

            foreach (MedicalAppointment appointment in doctorsAppointments)
            {
                if (appointment.DateRange.StartTime > DateTime.Now /*!appointment.isDone*/)
                {
                    doctorsCurrentAppointments.Add(appointment);
                }
            }
            return doctorsCurrentAppointments;
        }

        public IEnumerable<MedicalAppointment> GetDoctorsOldAppointments(Guid id)
        {
            IEnumerable<MedicalAppointment> doctorsAppointments = GetDoctorAppointments(id);
            List<MedicalAppointment> doctorsOldAppointments = new List<MedicalAppointment>();

            foreach (MedicalAppointment appointment in doctorsAppointments)
            {
                if (appointment.DateRange.StartTime < DateTime.Now /*appointment.isDone*/)
                {
                    doctorsOldAppointments.Add(appointment);
                }
            }
            return doctorsOldAppointments;
        }

        public void deleteAppointmentEndSendNotification(Guid appointmentId)
        {
            MedicalAppointment medicalAppointment = _medicalAppointmentRepository.GetById(appointmentId);

            String recipientName = medicalAppointment.Patient.Name + " " + medicalAppointment.Patient.Surname;
            //String recipientEmail = appointment.Patient.Email;
            String recipientEmail = "the2922000@gmail.com";
            String subject = "Otkazivanje pregleda";
            String emailText = "Vaš pregled dana " + medicalAppointment.DateRange.StartTime.ToString("dd.MM.yyyy. dd:mm") + " je otkazan";

            _medicalAppointmentRepository.Delete(appointmentId);
            MimeMessage emailMessage = EmailSending.createTxtEmail(recipientName,recipientEmail,subject,emailText );
            EmailSending.sendEmail(emailMessage);
        }
    }
}
