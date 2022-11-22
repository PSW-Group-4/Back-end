using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Repository;

namespace HospitalLibrary.Appointments.Service
{
    public class RoomScheduleService : IRoomScheduleService
    {
        private readonly IRoomScheduleRepository _scheduleRepository;

        public RoomScheduleService(IRoomScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public IEnumerable<RoomSchedule> GetAll()
        {
            return _scheduleRepository.GetAll();
        }

        public RoomSchedule GetById(Guid id)
        {
            return _scheduleRepository.GetById(id);
        }

        public RoomSchedule Create(RoomSchedule schedule)
        {
            return _scheduleRepository.Create(schedule);
        }

        public RoomSchedule Update(RoomSchedule schedule)
        {
            return _scheduleRepository.Update(schedule);
        }

        public void Delete(Guid scheduleId)
        {
            _scheduleRepository.Delete(scheduleId);
        }
    }
}