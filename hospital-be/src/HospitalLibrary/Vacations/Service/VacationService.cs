using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Doctors.Service;
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
        private readonly IDoctorService _doctorService;

        public VacationService(IVacationRepository vacationRepository, IDoctorAppointmentService doctorAppointmentService, IDoctorService doctorService)
        {
            _vacationRepository = vacationRepository;
            _doctorAppointmentService = doctorAppointmentService;
            _doctorService = doctorService;
        }

        public IEnumerable<Vacation> GetAll()
        {
            return _vacationRepository.GetAll();
        }

        public Vacation GetById(Guid id)
        {
            return _vacationRepository.GetById(id);
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

        public Vacation Create(Vacation vacation)
        {
            if (!(isDateValid(vacation.DateStart)))
            {
                return null;
            }
            if (CheckDoctorAvailability(vacation))
            {
                return _vacationRepository.Create(vacation);
            }
            if (vacation.Urgent == true)
            {
                return CreateUrgentVacation(vacation);
            }
            return null;
        }

        public bool isDateValid(DateTime vacationStart)
        {
            if (DateTime.Today.AddDays(6) < vacationStart)
            {
                return true;
            }
            return false;
        }

        public bool CheckDoctorAvailability(Vacation vacation)
        {
            bool canCreateVacation = true;
            IEnumerable<MedicalAppointment> doctorAppointments = _doctorAppointmentService.GetDoctorAppointments(vacation.DoctorId);

            foreach (MedicalAppointment doctorAppointment in doctorAppointments)
            {
                if (!((doctorAppointment.DateRange.StartTime<vacation.DateStart && doctorAppointment.DateRange.StartTime < vacation.DateEnd)
                    || doctorAppointment.DateRange.EndTime > vacation.DateStart && doctorAppointment.DateRange.EndTime > vacation.DateEnd))
                {
                    canCreateVacation = false;
                    break;
                }
            }

            return canCreateVacation;

        }

        public Vacation CreateUrgentVacation(Vacation vacation)
        {
            bool doctorChanged = CheckAvailableDoctorsToSwitchAppointments(vacation);
            if (doctorChanged)
            {
                return _vacationRepository.Create(vacation);
            }
            return null;
        }

        public bool CheckAvailableDoctorsToSwitchAppointments(Vacation vacation)
        {
            bool doctorChanged = false;

            if(SwitchDoctorFound(vacation))
            {
                doctorChanged = true;
            }

            return doctorChanged;
        }

        public bool SwitchDoctorFound(Vacation vacation)
        {
            Doctor currentDoctor = _doctorService.GetById(vacation.DoctorId);
            IEnumerable<Doctor> doctors = _doctorService.GetAll();
            
            foreach(Doctor doctor in doctors)
            {
                bool doctorFound = true;
                IEnumerable<MedicalAppointment> doctorAppointments = _doctorAppointmentService.GetDoctorAppointments(doctor.Id);
                foreach(MedicalAppointment appointment in doctorAppointments)
                {
                    if(appointment.DateRange.StartTime.Date > vacation.DateStart && appointment.DateRange.StartTime.Date < vacation.DateEnd)
                    {
                        doctorFound = false;
                        break;
                    }
                }
                if (doctorFound)
                {
                    //SwitchAppointmentsToAnotherDoctor(doctor.Id, vacation);
                    return true;
                }
            }
            return false;
            
        }

        public void SwitchAppointmentsToAnotherDoctor(Guid doctorId, Vacation vacation)
        {
            Doctor availableSwitchDoctor = _doctorService.GetById(doctorId);
            Doctor currentDoctor = _doctorService.GetById(vacation.DoctorId);
            IEnumerable<MedicalAppointment> doctorAppointments = _doctorAppointmentService.GetDoctorAppointments(vacation.DoctorId);

            foreach (MedicalAppointment appointment in doctorAppointments)
            {
                if(appointment.DateRange.StartTime > vacation.DateStart &&
                    appointment.DateRange.StartTime < vacation.DateEnd)
                {
                    appointment.SwitchRoomAndDoctor(availableSwitchDoctor.Id, availableSwitchDoctor.RoomId);
                    // appointment.DoctorId = availableSwitchDoctor.Id;
                    // appointment.RoomId = availableSwitchDoctor.RoomId;
                    // updejtuj apojntment
                }
            }
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

        public IEnumerable<Vacation> GetAllPastByDoctorId(Guid doctorId)
        {
            return _vacationRepository.GetAllPastByDoctorId(doctorId);
        }

        public List<int> GetNumberOfVacationsPerMonth(Guid doctorId)
        {
            List<int> returnList = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; //init lista 0, svaki broj predstavlja broj iskoriscenih dana u mesecu, prvi broj januar itd...
            IEnumerable<Vacation> vacations = _vacationRepository.GetAllPastByDoctorId(doctorId);

            foreach(Vacation v in vacations)
            {
                int numberOfDays = (v.DateEnd - v.DateStart).Days;

                if(numberOfDays > 31)
                {
                    returnList[v.DateStart.Month - 1] = returnList[v.DateStart.Month - 1] + 31;
                    returnList[v.DateStart.Month] = returnList[v.DateStart.Month] + (numberOfDays - 31);
                }
                else
                {
                    returnList[v.DateStart.Month - 1] = returnList[v.DateStart.Month - 1] + numberOfDays;
                }
            }

            return returnList;
        }

        public IEnumerable<Vacation> GetAllManager()
        {
            return _vacationRepository.GetAllManager();
        }
    }
}
