using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.Doctors.Repository;
using System;
using System.Collections.Generic;
using IntegrationLibrary.Utilities;
using MimeKit;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;

namespace HospitalLibrary.Appointments.Service
{
    public class DoctorAppointmentService : IDoctorAppointmentService
    {
        private readonly IMedicalAppointmentService _medicalAppointmentService;
        private readonly IDoctorRepository _doctorRepository;

        public DoctorAppointmentService(IMedicalAppointmentService medicalAppointmentService, IDoctorRepository doctorRepository)
        {
            _medicalAppointmentService = medicalAppointmentService;
            _doctorRepository = doctorRepository;
        }

        public IEnumerable<MedicalAppointment> GetDoctorAppointments(Guid id)
        {
            IEnumerable<MedicalAppointment> allAppointments = _medicalAppointmentService.GetAll();
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

        public Doctor getDoctor()
        {
            Guid id = new Guid("487d0767-1f8b-4a09-a593-4f076bdb9881");
            return _doctorRepository.GetById(id);
        }

        public void deleteAppointmentEndSendNotification(Guid appointmentId)
        {
            MedicalAppointment medicalAppointment = _medicalAppointmentService.GetById(appointmentId);

            String recipientName = medicalAppointment.Patient.Name + " " + medicalAppointment.Patient.Surname;
            //String recipientEmail = appointment.Patient.Email;
            String recipientEmail = "the2922000@gmail.com";
            String subject = "Otkazivanje pregleda";
            String emailText = "Vaš pregled dana " + medicalAppointment.DateRange.StartTime.ToString("dd.MM.yyyy. dd:mm") + " je otkazan";

            _medicalAppointmentService.Delete(appointmentId);
            MimeMessage emailMessage = EmailSending.createTxtEmail(recipientName,recipientEmail,subject,emailText );
            EmailSending.sendEmail(emailMessage);
        }
        //TODO refactor
        //PETAR
        public bool IsDoctorAvailable(DateTime time)
        {
            IEnumerable<MedicalAppointment> appointments = _medicalAppointmentService.GetAll();
            foreach (MedicalAppointment appointment in appointments)
            {
                if (appointment.DateRange.StartTime.Equals(time))
                    return false;
            }
            return IsDoctorWorkTimeAvailable(time);
        }
        //PETAR
        public List<DateRange> AvailableTerminsForDate(DateTime date,Guid patientId)
        {
            List<DateRange> list = new List<DateRange>();

            DateTime WorkTimeStart = new DateTime(date.Year, date.Month, date.Day, DateTime.Parse(getDoctor().WorkingTimeStart).Hour, DateTime.Parse(getDoctor().WorkingTimeStart).Minute, 0);
            DateTime WorkTimeEnd = new DateTime(date.Year, date.Month, date.Day, DateTime.Parse(getDoctor().WorkingTimeEnd).Hour, DateTime.Parse(getDoctor().WorkingTimeEnd).Minute, 0);
            
            while (DateTime.Compare(WorkTimeEnd, WorkTimeStart) > 0)
            {
                DateRange terminRange = new DateRange(WorkTimeStart, WorkTimeEnd);
                if (IsDoctorAvailable(WorkTimeStart) && _medicalAppointmentService.IsPatientFree(patientId, terminRange))
                {
                    DateRange dateRange = new DateRange(WorkTimeStart, WorkTimeStart.AddMinutes(30));
                    list.Add(dateRange);
                }
                WorkTimeStart = WorkTimeStart.AddMinutes(30);
            }
            return list;
        }
        //TODO izbaci
        public bool IsDoctorWorkTimeAvailable(DateTime time)
        {
            Doctor doctor = getDoctor();
            DateTime WorkTimeStart = DateTime.Parse(doctor.WorkingTimeStart);
            DateTime WorkTimeEnd = DateTime.Parse(doctor.WorkingTimeEnd);
            if ((WorkTimeStart.Hour <= time.Hour) && (WorkTimeEnd.Hour > time.Hour))
                return true;
            return false;
        }
    }
}
