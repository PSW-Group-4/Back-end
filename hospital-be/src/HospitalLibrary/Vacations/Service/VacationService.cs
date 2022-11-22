using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.Vacations.Model;
using HospitalLibrary.Vacations.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Vacations.Service
{
    public class VacationService : IVacationService
    {
        private readonly IVacationRepository _vacationRepository;
        private readonly IDoctorAppointmentService _doctorAppointmentService;

        public VacationService(IVacationRepository vacationRepository, IDoctorAppointmentService doctorAppointmentService)
        {
            _vacationRepository = vacationRepository;
            _doctorAppointmentService = doctorAppointmentService;
        }

        public IEnumerable<Vacation> GetAll()
        {
            return _vacationRepository.GetAll();
        }

        public Vacation GetById(Guid id)
        {
            return _vacationRepository.GetById(id);
        }
        public Vacation Create(Vacation vacation)
        {
            // should be complicated :D
            return _vacationRepository.Create(vacation);
        }

        public void Delete(Guid vacationId)
        {
            var vacation = GetById(vacationId);
            if (vacation.VacationStatus.Equals(VacationStatus.Waiting_For_Approval))
            {
                _vacationRepository.Delete(vacationId);
            }
        }

        public Vacation Update(Vacation vacation)
        {
            return _vacationRepository.Update(vacation);
        }


        public bool CheckDoctorAvailability(Guid doctorId, DateTime start, DateTime end)
        {
            bool canCreateVacation = true;
            IEnumerable<Appointment> doctorAppointments = _doctorAppointmentService.GetDoctorAppointments(doctorId);

            foreach (Appointment doctorAppointment in doctorAppointments)
            {
                if (!((doctorAppointment.DateTime<start && doctorAppointment.DateTime < start)
                    || doctorAppointment.DateTime.AddMinutes(30)>start && doctorAppointment.DateTime.AddMinutes(30)>end))
                {
                    canCreateVacation = false;
                    break;
                }
            }

            return canCreateVacation;

        }

        public IEnumerable<Vacation> GetDoctorVacationsFromSpecificStatus(VacationStatus vacationStatus ,Guid DoctorId)
        {
            IEnumerable<Vacation> vacations = GetAll();
            List<Vacation> doctorVacations = new List<Vacation>();

            foreach (Vacation vacation in vacations)
            {
                if (vacation.DoctorId.Equals(DoctorId) && vacation.VacationStatus.Equals(vacationStatus))
                {
                    doctorVacations.Add(vacation);
                }
            }


            return doctorVacations;
        }
    }
}
