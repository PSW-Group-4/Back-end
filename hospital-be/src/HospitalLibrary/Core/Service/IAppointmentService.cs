using System;
using System.Collections.Generic;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Infrastructure.CRUD;

namespace HospitalLibrary.Core.Service
{
    public interface IAppointmentService : ICrudService<Appointment>
    {
        public List<Appointment> getAll();
        public void CheckIfAppointmentIsDone();
        public IEnumerable<DateTime> RecommendStartForRelocationOrRenovation(EquipmentRelocation.DTO.EquipmentRelocationDTO dto);
        public IEnumerable<DateTime> GetAvailableDates(Guid roomId, DateRange dateRange, int duration);

    }
}
