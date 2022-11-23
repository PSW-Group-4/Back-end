using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Appointments.Model;

namespace HospitalLibrary.Appointments.Service
{
    public interface IRoomScheduleService
    {
        IEnumerable<RoomSchedule> GetAll();
        RoomSchedule GetById(Guid id);
        RoomSchedule Create(RoomSchedule schedule);
        RoomSchedule Update(RoomSchedule schedule);
        void Delete(Guid scheduleId);
    }
}