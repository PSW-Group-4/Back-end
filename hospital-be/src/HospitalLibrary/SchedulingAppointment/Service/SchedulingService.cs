using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Doctors.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.SchedulingAppointment.Service
{
    public class SchedulingService : ISchedulingService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorService _dctorService;
        public SchedulingService(IAppointmentRepository appointmentRepository, IDoctorService doctorService)
        {
            _appointmentRepository = appointmentRepository;
            _dctorService = doctorService;
        }
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
        public bool IsDoctorWorkTimeAvailable(DateTime time)
        {
            Doctor doctor = getDoctor();
            DateTime WorkTimeStart = DateTime.Parse(doctor.WorkingTimeStart);
            DateTime WorkTimeEnd = DateTime.Parse(doctor.WorkingTimeEnd);
            if ((WorkTimeStart.Hour <= time.Hour) && (WorkTimeEnd.Hour > time.Hour))
                return true;
            return false;
        }
        public List<Appointment> getAll()
        {
            return (List<Appointment>)_appointmentRepository.GetAll();
        }
        public Doctor getDoctor()
        {
            Guid id = new Guid("487d0767-1f8b-4a09-a593-4f076bdb9881");
            return _dctorService.GetById(id);
        }
        public List<DateTime> AvailableTerminsForDate(DateTime date)
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
            List<Appointment> appointments = getAll();
            foreach (Appointment appointment in appointments)
                if (!appointment.Schedule.IsDone && (DateTime.Compare(appointment.Schedule.DateTime, DateTime.Now) < 0))
                {
                    appointment.Schedule.IsDone = true;
                    _appointmentRepository.Update(appointment);
                }
        }
    }
}
