using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.Doctors.Repository;
using System;
using System.Collections.Generic;
using IntegrationLibrary.Utilities;
using MimeKit;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Vacations.Service;
using HospitalLibrary.Vacations.Repository;
using HospitalLibrary.Consiliums.Repository;
using Org.BouncyCastle.Asn1.Ocsp;
using HospitalLibrary.Utility;
using HospitalLibrary.Exceptions;
using iTextSharp.text;
using System.Linq;
using HospitalLibrary.Vacations.Model;

namespace HospitalLibrary.Appointments.Service
{
    public class DoctorAppointmentService : IDoctorAppointmentService
    {
        private readonly IMedicalAppointmentService _medicalAppointmentService;
        private readonly IDoctorRepository _doctorRepository;
        //private readonly IVacationService _vacationService;
        private readonly IVacationRepository _vacationRepository;
        private readonly IConsiliumRepository _consiliumRepository;

        public DoctorAppointmentService(IMedicalAppointmentService medicalAppointmentService, IDoctorRepository doctorRepository, IVacationRepository vacationRepository, IConsiliumRepository consiliumRepository)
        {
            _medicalAppointmentService = medicalAppointmentService;
            _doctorRepository = doctorRepository;
            _vacationRepository = vacationRepository;
            _consiliumRepository = consiliumRepository;
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

        public void deleteAppointmentEndSendNotification(Guid appointmentId)
        {
            MedicalAppointment medicalAppointment = _medicalAppointmentService.GetById(appointmentId);

            String recipientName = medicalAppointment.Patient.Name + " " + medicalAppointment.Patient.Surname;
            //String recipientEmail = appointment.Patient.Email;
            String recipientEmail = "the2922000@gmail.com";
            String subject = "Otkazivanje pregleda";
            String emailText = "Vaš pregled dana " + medicalAppointment.DateRange.StartTime.ToString("dd.MM.yyyy. dd:mm") + " je otkazan";

            _medicalAppointmentService.Delete(appointmentId);
            MimeMessage emailMessage = EmailSending.CreateTxtEmail(recipientName,recipientEmail,subject,emailText );
            EmailSending.SendEmail(emailMessage);
        }
        
        //PETAR
        public List<DateRange> AvailableTerminsForDate(DateTime date,Guid patientId, Guid doctorId)
        {
            List<DateRange> list = new List<DateRange>();

            DateTime WorkTimeStart = new DateTime(date.Year, date.Month, date.Day, DateTime.Parse(_doctorRepository.GetById(doctorId).WorkingTimeStart).Hour, DateTime.Parse(_doctorRepository.GetById(doctorId).WorkingTimeStart).Minute, 0);
            DateTime WorkTimeEnd = new DateTime(date.Year, date.Month, date.Day, DateTime.Parse(_doctorRepository.GetById(doctorId).WorkingTimeEnd).Hour, DateTime.Parse(_doctorRepository.GetById(doctorId).WorkingTimeEnd).Minute, 0);
            
            while (DateTime.Compare(WorkTimeEnd, WorkTimeStart) > 0)
            {
                DateRange terminRange = new DateRange(WorkTimeStart, WorkTimeEnd);
                if (IsDoctorAvailable(doctorId, WorkTimeStart) && _medicalAppointmentService.IsPatientFree(patientId, terminRange))
                {
                    DateRange dateRange = new DateRange(WorkTimeStart, WorkTimeStart.AddMinutes(30));
                    list.Add(dateRange);
                }
                WorkTimeStart = WorkTimeStart.AddMinutes(30);
            }
            return list;
        }
        
        //STEFAN
        public List<AppointmentSuggestionsWithTheirDoctors> GetAppointmentSuggestionsForDateRange(
            RequestForAppointmentSlotSuggestions request)
        {
            List<AppointmentSuggestionsWithTheirDoctors> result =
                new List<AppointmentSuggestionsWithTheirDoctors>();

            FixDatesForTimezone(request);

            foreach (DateTime date in SetupRequestDates(request.StartDate, request.EndDate))
            {
                
                result.AddRange(MapSuggestionsWithDesiredDoctor(request, date));
            }

            if (result.Count == 0)
            {
                return GetSuggestionsByPriority(request);
            }
            return result;
        }

        private List<AppointmentSuggestionsWithTheirDoctors> MapSuggestionsWithDesiredDoctor(
            RequestForAppointmentSlotSuggestions request, DateTime date)
        {
            List<AppointmentSuggestionsWithTheirDoctors> result =
                                new List<AppointmentSuggestionsWithTheirDoctors>();

            List<DateRange> suggestions =
                AvailableTerminsForDate(date, request.RequestingPatientId, request.DoctorId);

            foreach(var item in suggestions)
            {
                result.Add(new AppointmentSuggestionsWithTheirDoctors()
                { Id = request.DoctorId, appointmentSuggestions = item, Name = "", Surname = "" });
            }

            return result;
        }

        private static void FixDatesForTimezone(RequestForAppointmentSlotSuggestions request)
        {
            request.StartDate = request.StartDate.AddDays(1);
            request.EndDate = request.EndDate.AddDays(1);
        }

        private List<AppointmentSuggestionsWithTheirDoctors> GetSuggestionsByPriority(
            RequestForAppointmentSlotSuggestions request)
        {
            var result = new List<AppointmentSuggestionsWithTheirDoctors>();
            switch (request.Priority) 
            {
                case "Doctor":
                    {
                        return GetSuggestionsByDoctor(request, result);
                    }
                case "Date":
                    {
                        return GetSuggestionsByDate(request, result);
                    }
                default:
                    {
                        throw new InvalidPriorityException();
                    }
            }
        }

        private List<AppointmentSuggestionsWithTheirDoctors> GetSuggestionsByDate(
            RequestForAppointmentSlotSuggestions request, List<AppointmentSuggestionsWithTheirDoctors> result)
        {
            List<Doctor> otherDoctorsOfTheSameSpeciality = _doctorRepository.GetDoctorsWithSpecialty(
                _doctorRepository.GetById(request.DoctorId).Speciality).Where
                (r => r.Id != request.DoctorId).ToList();

            foreach (Doctor doc in otherDoctorsOfTheSameSpeciality)
            {
                foreach (DateTime date in SetupRequestDates(request.StartDate, request.EndDate))
                {
                    result.AddRange(MapSuggestionsWithOtherDoctorsOfTheSameSpeciality(doc, request, date));
                    //result.AddRange(AvailableTerminsForDate(date, request.RequestingPatientId, doc.Id));
                }
            }
            return result;
        }

        private List<AppointmentSuggestionsWithTheirDoctors> MapSuggestionsWithOtherDoctorsOfTheSameSpeciality(
            Doctor doc, RequestForAppointmentSlotSuggestions request, DateTime date)
        {
            List<AppointmentSuggestionsWithTheirDoctors> result =
                new List<AppointmentSuggestionsWithTheirDoctors>();

            List<DateRange> suggestions =
                AvailableTerminsForDate(date, request.RequestingPatientId, doc.Id);

            foreach(var item in suggestions)
            {
                result.Add(new AppointmentSuggestionsWithTheirDoctors()
                { Id = doc.Id, appointmentSuggestions = item, Name = doc.Name, Surname = doc.Surname });
            }

            return result;
        }

        private List<AppointmentSuggestionsWithTheirDoctors> GetSuggestionsByDoctor(
            RequestForAppointmentSlotSuggestions request, List<AppointmentSuggestionsWithTheirDoctors> result)
        {
            foreach (DateTime date in SetupDoctorPriorityDates(request.StartDate, request.EndDate))
            {
                result.AddRange(MapSuggestionsWithDesiredDoctor(request, date));
                //result.AddRange(AvailableTerminsForDate(date, request.RequestingPatientId, request.DoctorId));
            }
            return result;
        }

        private List<DateTime> SetupDoctorPriorityDates(DateTime startDate, DateTime endDate)
        {
            var result = new List<DateTime>();

            for (int i = 1; i <= 5; i++)   //doctor ignores the date, but appointments must be 5 days before/after the chosen date
            {
                if (startDate.AddDays(-i) > DateTime.Now)
                {
                    result.Add(startDate.AddDays(-i));
                }
                result.Add(endDate.AddDays(i));
            }
            return result;
        }

        private IEnumerable<DateTime> SetupRequestDates(DateTime startDate, DateTime endDate) 
        {
            for (var day = startDate.Date; day.Date <= endDate.Date; day = day.AddDays(1))
            {
                yield return day;
            }
        }

        public List<DateRange> getAvailableTerminsForAnotherDoctor(DateTime timeStart, DateTime timeEnd, Guid patientId, Guid doctorId)
        {
            List<DateRange> res = new List<DateRange>();
            DateRange dateRange = new DateRange(timeStart, timeEnd);
            DateTime start = new DateTime(dateRange.StartTime.Year, dateRange.StartTime.Month, dateRange.StartTime.Day, DateTime.Parse(_doctorRepository.GetById(doctorId).WorkingTimeStart).Hour, DateTime.Parse(_doctorRepository.GetById(doctorId).WorkingTimeStart).Minute, 0);
            DateTime WorkTimeStart = new DateTime(dateRange.StartTime.Year, dateRange.StartTime.Month, dateRange.StartTime.Day, DateTime.Parse(_doctorRepository.GetById(doctorId).WorkingTimeStart).Hour, DateTime.Parse(_doctorRepository.GetById(doctorId).WorkingTimeStart).Minute, 0);
            DateTime WorkTimeEnd = new DateTime(dateRange.StartTime.Year, dateRange.StartTime.Month, dateRange.StartTime.Day, DateTime.Parse(_doctorRepository.GetById(doctorId).WorkingTimeEnd).Hour, DateTime.Parse(_doctorRepository.GetById(doctorId).WorkingTimeEnd).Minute, 0);
            timeEnd = timeEnd.AddDays(1);
            double addDays = 1;

            
            while (DateTime.Compare(timeEnd, WorkTimeStart) > 0)
            {                
                DateRange terminRange = new DateRange(WorkTimeStart, WorkTimeEnd);
                if (IsDoctorAvailable(doctorId, WorkTimeStart) && _medicalAppointmentService.IsPatientFree(patientId, terminRange))
                {
                    DateRange abailableTerin = new DateRange(WorkTimeStart, WorkTimeStart.AddMinutes(30));
                    res.Add(abailableTerin);
                }
                WorkTimeStart = WorkTimeStart.AddMinutes(30);
                if(DateTime.Compare(WorkTimeStart, WorkTimeEnd) > 0)
                {                    
                    WorkTimeStart = start;
                    WorkTimeEnd = WorkTimeEnd.AddDays(1);
                    WorkTimeStart = WorkTimeStart.AddDays(1);                    
                }           
                
            } 
            return res;
        }

        //TODO refactor
        //PETAR
        public bool IsDoctorAvailable(Guid doctorId, DateTime time)
        {
            Doctor doctor = _doctorRepository.GetById(doctorId);
            // da li je u radnom vremenu termin
            if (!doctor.IsInWorkHours(time))
            {
                return false;
            }
            // da li je doktor na godisnjem
            //if (_vacationService.IsDoctorOnVacation(doctorId, time))
            if(_vacationRepository.IsDoctorOnVacation(doctorId, time))
            {
                return false;
            }
            // da li doktor tad ima pregled
            if (IsDoctorOnMedicalAppointment(doctor, time))
            {
                return false;
            }
            // da li doktor na sastanku
            if (_consiliumRepository.IsDoctorOnConsilium(doctorId, time))
            {
                return false;
            }
            return true;

            /*
            IEnumerable<MedicalAppointment> appointments = _medicalAppointmentService.GetAll();
            foreach (MedicalAppointment appointment in appointments)
            {
                if (appointment.DateRange.StartTime.Equals(time))
                    return false;
            }
            return IsDoctorWorkTimeAvailable(time);*/
        }

        private bool IsDoctorOnMedicalAppointment(Doctor doctor, DateTime date)
        {
            IEnumerable<MedicalAppointment> allDoctorsAppointments = GetDoctorAppointments(doctor.Id);
            foreach (MedicalAppointment appointment in allDoctorsAppointments)
            {
                if(DateTime.Compare(date, appointment.DateRange.StartTime) >= 0
                && DateTime.Compare(date, appointment.DateRange.EndTime) < 0)
                {
                    return true;
                }
            }
            return false;
            
        }

        public List<int> GetAppointmentsPerYear(Guid doctorId, int selectedYear)
        {
            List<int> returnList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; 
            IEnumerable<MedicalAppointment> appointments = GetDoctorAppointments(doctorId);

            foreach (MedicalAppointment v in appointments)
            {
                if(v.DateRange.EndTime.Year == selectedYear)
                {
                    returnList[v.DateRange.EndTime.Month - 1] += 1;
                }
            }
            return returnList;
        }

        public List<int> GetAppointmentsPerMonth(Guid doctorId, int selectedYear, int selectedMonth)
        {
            List<int> returnList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            IEnumerable<MedicalAppointment> appointments = GetDoctorAppointments(doctorId);

            foreach (MedicalAppointment v in appointments)
            {
                if (v.DateRange.EndTime.Year == selectedYear && v.DateRange.EndTime.Month == selectedMonth)
                {
                    returnList[v.DateRange.EndTime.Day - 1] += 1;
                }
            }
            return returnList;
        }
    



        //TODO izbaci
        /*public bool IsDoctorWorkTimeAvailable(DateTime time)
        {
            Doctor doctor = getDoctor();
            DateTime WorkTimeStart = DateTime.Parse(doctor.WorkingTimeStart);
            DateTime WorkTimeEnd = DateTime.Parse(doctor.WorkingTimeEnd);
            if ((WorkTimeStart.Hour <= time.Hour) && (WorkTimeEnd.Hour > time.Hour))
                return true;
            return false;
        }*/
    }
}
