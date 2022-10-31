using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Doctors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.SchedulingAppointment.Service
{
    public interface ISchedulingService
    {
        public bool IsAvailable(DateTime time);
        public bool IsDoctorWorkTimeAvailable(DateTime time);
        public List<Appointment> getAll();
        public Doctor getDoctor();
        public List<DateTime> AvailableTerminsForDate(DateTime date);
        public void UpdateDoneAppointments();

    }
}
