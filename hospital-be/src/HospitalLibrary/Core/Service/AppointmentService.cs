using System;
using System.Collections.Generic;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Doctors.Service;
using System.Linq;

namespace HospitalLibrary.Core.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorService _dctorService;
        public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorService doctorService)
        {
            _appointmentRepository = appointmentRepository;
            _dctorService = doctorService;
        }
        public List<Appointment> getAll()
        {
            return (List<Appointment>)_appointmentRepository.GetAll();
        }

        //PETAR
        public void CheckIfAppointmentIsDone() 
        {
            List<Appointment> appointments = getAll();
            foreach (Appointment appointment in appointments)
                if (!appointment.IsDone && (DateTime.Compare(appointment.DateRange.StartTime, DateTime.Now) < 0))
                {
                    appointment.FinishAppointment();
                    _appointmentRepository.Update(appointment);
                }
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment GetById(Guid id)
        {
            return _appointmentRepository.GetById(id);
        }

        public Appointment Create(Appointment entity)
        {
            return _appointmentRepository.Create(entity);
        }

        public Appointment Update(Appointment entity)
        {
            return _appointmentRepository.Update(entity);
        }

        public void Delete(Guid entityId)
        {
            _appointmentRepository.Delete(entityId);
        }
        //Bojana
        public IEnumerable<DateTime> RecommendStartForRelocationOrRenovation(EquipmentRelocation.DTO.EquipmentRelocationDTO dto)
        {
            IEnumerable<DateTime> sourceDates = GetAvailableDates(dto.SourceId, dto.DateRange, dto.Duration);
            IEnumerable<DateTime> targetDates = GetAvailableDates(dto.TargetId, dto.DateRange, dto.Duration);
            return sourceDates.Intersect(targetDates);
        }

        public IEnumerable<DateTime> GetAvailableDates(Guid roomId, DateRange dateRange, int duration)
        {
            List<DateTime> result = new List<DateTime>();
            DateRange start = new DateRange(dateRange.StartTime, dateRange.StartTime.AddMinutes(duration));
            Boolean shouldAdd; 
            do
            {
                shouldAdd = true;
                foreach (Appointment appointment in GetAll())
                {
                    if (appointment.RoomId.Equals(roomId) && appointment.DateRange.OverlapsWith(start))
                    {
                        shouldAdd = false;
                        break;
                    }
                }
                if (!result.Contains(start.StartTime) && shouldAdd == true)
                {
                     result.Add(start.StartTime);
                }
                start = new DateRange(start.StartTime.AddMinutes(15), start.EndTime.AddMinutes(15));
            } while (dateRange.EndTime >= start.EndTime);
            return result;
        }

    }
}
