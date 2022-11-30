using System;
using System.Collections.Generic;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Doctors.Service;

namespace HospitalLibrary.Core.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IMedicalAppointmentRepository _medicalAppointmentRepository;
        private readonly IDoctorService _dctorService;
        public AppointmentService(IMedicalAppointmentRepository medicalAppointmentRepository, IDoctorService doctorService)
        {
            _medicalAppointmentRepository = medicalAppointmentRepository;
            _dctorService = doctorService;
        }
        //TODO refactor
        public bool IsAvailable(DateTime time)
        {
            List<Appointment> appointments = getAll();
            foreach(Appointment appointment in appointments)
            {
                if (appointment.Schedule.DateTime.Equals(time))
                    return false;
            }
            return IsDoctorWorkTimeAvailable(time);
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
        public List<MedicalAppointment> getAll()
        {
            return (List<MedicalAppointment>)_medicalAppointmentRepository.GetAll();
        }
        public Doctor getDoctor()
        {
            Guid id = new Guid("487d0767-1f8b-4a09-a593-4f076bdb9881");
            return _dctorService.GetById(id);
        }
        public List<DateRange> AvailableTerminsForDate(DateTime date)
        {
            List<DateTime> list = new List<DateTime>();
            DateTime WorkTimeStart = new DateTime(date.Year,date.Month,date.Day, DateTime.Parse(getDoctor().WorkingTimeStart).Hour, DateTime.Parse(getDoctor().WorkingTimeStart).Minute,0);
            DateTime WorkTimeEnd = new DateTime(date.Year, date.Month, date.Day, DateTime.Parse(getDoctor().WorkingTimeEnd).Hour, DateTime.Parse(getDoctor().WorkingTimeEnd).Minute, 0);
            while (DateTime.Compare(WorkTimeEnd,WorkTimeStart)>0)
            {
                if(IsAvailable(WorkTimeStart))
                    list.Add(WorkTimeStart);
                WorkTimeStart = WorkTimeStart.AddMinutes(30);
            }
            return list;
        }
        public void UpdateDoneAppointments() 
        {
            List<MedicalAppointment> appointments = getAll();
            foreach (MedicalAppointment appointment in appointments)
                if (!appointment.Schedule.IsDone && (DateTime.Compare(appointment.Schedule.DateTime, DateTime.Now) < 0))
                {
                    appointment.Schedule.IsDone = true;
                    _medicalAppointmentRepository.Update(appointment);
                }
        }
    }
}
