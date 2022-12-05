using System;
using System.Collections.Generic;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Doctors.Service;

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
        //TODO refactor
        //PETAR
        public bool IsAvailable(DateTime time)
        {
            List<Appointment> appointments = getAll();
            foreach(Appointment appointment in appointments)
            {
                if (appointment.DateRange.StartTime.Equals(time))
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
        public List<Appointment> getAll()
        {
            return (List<Appointment>)_appointmentRepository.GetAll();
        }
        public Doctor getDoctor()
        {
            Guid id = new Guid("487d0767-1f8b-4a09-a593-4f076bdb9881");
            return _dctorService.GetById(id);
        }

        List<DateTime> IAppointmentService.AvailableTerminsForDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        //PETAR
        public List<DateRange> AvailableTerminsForDate(DateTime date)
        {
            List<DateRange> list = new List<DateRange>();
            
            DateTime WorkTimeStart = new DateTime(date.Year,date.Month,date.Day, DateTime.Parse(getDoctor().WorkingTimeStart).Hour, DateTime.Parse(getDoctor().WorkingTimeStart).Minute,0);
            DateTime WorkTimeEnd = new DateTime(date.Year, date.Month, date.Day, DateTime.Parse(getDoctor().WorkingTimeEnd).Hour, DateTime.Parse(getDoctor().WorkingTimeEnd).Minute, 0);
            while (DateTime.Compare(WorkTimeEnd,WorkTimeStart)>0)
            {
                if (IsAvailable(WorkTimeStart))
                {
                    DateRange dateRange = new DateRange(WorkTimeStart, WorkTimeStart.AddMinutes(30));
                    list.Add(dateRange);
                }
                WorkTimeStart = WorkTimeStart.AddMinutes(30);
            }
            return list;
        }
        //PETAR
        public void CheckIfAppointmentIsDone() 
        {
            List<Appointment> appointments = getAll();
            foreach (Appointment appointment in appointments)
                if (!appointment.IsDone && (DateTime.Compare(appointment.DateRange.StartTime, DateTime.Now) < 0))
                {
                    appointment.IsDone = true;
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
        public List<DateTime> RecommendStartForRelocationOrRenovation(EquipmentRelocation.DTO.EquipmentRelocationDTO dto)
        {
            DateRange dateRange = dto.CheckDateRange(dto.DateRange);
            dto.Duration = CheckDuration(dto.Duration);

            return GetAvailableDatesForRelocationOrRenovation(dto, dateRange);
        }

        //Bojana
        public List<DateTime> GetAvailableDatesForRelocationOrRenovation(HospitalLibrary.EquipmentRelocation.DTO.EquipmentRelocationDTO dto, DateRange dateRange)

        {
            IEnumerable<Appointment> appointments = GetAll();
            List<DateTime> result = new List<DateTime>();
            DateTime start = dateRange.StartTime;
            Boolean shouldAdd = true;
            do
            {
                foreach (Appointment appointment in appointments)
                {
                    if (appointment.DateRange.StartTime.AddMinutes(30) > start && (appointment.RoomId.Equals(dto.TargetId) || appointment.RoomId.Equals(dto.SourceId)))
                    {
                        if ((start < appointment.DateRange.StartTime.AddMinutes(30)) && (appointment.DateRange.StartTime < start.AddMinutes(dto.Duration)))
                        {
                            shouldAdd = false;
                            break;
                        }
                    }
                }
                if (!result.Contains(start) && shouldAdd == true)
                {
                     result.Add(start);
                }
                start = dto.DateRange.StartTime.AddMinutes(15);
            } while (dto.DateRange.EndTime > start); ;
            return result;
        }


        private int CheckDuration(int duration)
        {
            if (duration % 15 != 0)
            {
                duration += 15 - duration % 15;
            }
            return duration;
        }

    }
}
