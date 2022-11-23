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
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;

        public DoctorAppointmentService(IAppointmentRepository appointmentRepository, IDoctorRepository doctorRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<Appointment> GetDoctorAppointments(Guid id)
        {
            IEnumerable<Appointment> allAppointments = _appointmentRepository.GetAll();
            List<Appointment> doctorsAppointments = new List<Appointment>();

            foreach (Appointment appointment in allAppointments)
            {
                if (appointment.DoctorId.Equals(id))
                {
                    doctorsAppointments.Add(appointment);
                }
            }
            return doctorsAppointments;
        }

        public IEnumerable<Appointment> GetDoctorsCurrentAppointments(Guid id)
        {
            IEnumerable<Appointment> doctorsAppointments = GetDoctorAppointments(id);
            List<Appointment> doctorsCurrentAppointments = new List<Appointment>();

            foreach (Appointment appointment in doctorsAppointments)
            {
                if (appointment.Schedule.DateTime > DateTime.Now /*!appointment.isDone*/)
                {
                    doctorsCurrentAppointments.Add(appointment);
                }
            }
            return doctorsCurrentAppointments;
        }

        public IEnumerable<Appointment> GetDoctorsOldAppointments(Guid id)
        {
            IEnumerable<Appointment> doctorsAppointments = GetDoctorAppointments(id);
            List<Appointment> doctorsOldAppointments = new List<Appointment>();

            foreach (Appointment appointment in doctorsAppointments)
            {
                if (appointment.Schedule.DateTime < DateTime.Now /*appointment.isDone*/)
                {
                    doctorsOldAppointments.Add(appointment);
                }
            }
            return doctorsOldAppointments;
        }

        public void deleteAppointmentEndSendNotification(Guid appointmentId)
        {
            Appointment appointment = _appointmentRepository.GetById(appointmentId);

            String recipientName = appointment.Patient.Name + " " + appointment.Patient.Surname;
            //String recipientEmail = appointment.Patient.Email;
            String recipientEmail = "the2922000@gmail.com";
            String subject = "Otkazivanje pregleda";
            String emailText = "Vaš pregled dana " + appointment.Schedule.DateTime.ToString("dd.MM.yyyy. dd:mm") + " je otkazan";

            _appointmentRepository.Delete(appointmentId);
            MimeMessage emailMessage = EmailSending.createTxtEmail(recipientName,recipientEmail,subject,emailText );
            EmailSending.sendEmail(emailMessage);
        }
    }
}
