using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.Doctors.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                if (appointment.DateTime > DateTime.Now /*!appointment.isDone*/)
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
                if (appointment.DateTime < DateTime.Now /*appointment.isDone*/)
                {
                    doctorsOldAppointments.Add(appointment);
                }
            }
            return doctorsOldAppointments;
        }
    }
}
