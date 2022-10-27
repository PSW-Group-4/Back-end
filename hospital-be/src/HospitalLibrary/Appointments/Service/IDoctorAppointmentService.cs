using HospitalLibrary.Appointments.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Appointments.Service
{
    public interface IDoctorAppointmentService
    {
        IEnumerable<Appointment> GetDoctorAppointments(Guid id);
        IEnumerable<Appointment> GetDoctorsOldAppointments(Guid id);
        IEnumerable<Appointment> GetDoctorsCurrentAppointments(Guid id);
    }
}
