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
    public class SchedulingService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorService _dctorService;
        public SchedulingService(IAppointmentRepository appointmentRepository, IDoctorService doctorService)
        {
            _appointmentRepository = appointmentRepository;
            _dctorService = doctorService;
        }
        public bool IsAvailavle(DateTime time)
        {
            List<Appointment> appointments = getAll();
            foreach(Appointment appointment in appointments)
            {
                if (appointment.DateTime.Equals(time))
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
            Guid id = new Guid("1412c639-c5e1-47a1-b29b-1fe935536612");
            return _dctorService.GetById(id);
        }
        public List<DateTime> AvailableTerminsForDate(DateTime date)
        {
            List<DateTime> list = new List<DateTime>();
            DateTime WorkTimeStart = new DateTime(date.Year,date.Month,date.Day, DateTime.Parse(getDoctor().WorkingTimeStart).Hour, DateTime.Parse(getDoctor().WorkingTimeStart).Minute,0);
            DateTime WorkTimeEnd = new DateTime(date.Year, date.Month, date.Day, DateTime.Parse(getDoctor().WorkingTimeEnd).Hour, DateTime.Parse(getDoctor().WorkingTimeEnd).Minute, 0);
            while (DateTime.Compare(WorkTimeEnd,WorkTimeStart)>0)
            {
                if(IsAvailavle(WorkTimeStart))
                    list.Add(WorkTimeStart);
                WorkTimeStart = WorkTimeStart.AddMinutes(30);
            }
            return list;
        }
        public void UpdateDoneAppointments() 
        {
            List<Appointment> appointments = getAll();
            foreach (Appointment appointment in appointments)
                if (!appointment.IsDone && (DateTime.Compare(appointment.DateTime, DateTime.Now) < 0))
                {
                    appointment.IsDone = true;
                    _appointmentRepository.Update(appointment);
                }
        }
    }
}
