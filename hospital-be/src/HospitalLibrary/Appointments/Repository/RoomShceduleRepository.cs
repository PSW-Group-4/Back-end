using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.Exceptions;

namespace HospitalLibrary.Appointments.Repository
{
    public class RoomScheduleRepository : IRoomScheduleRepository
    {
        private readonly HospitalDbContext _context;

        public RoomScheduleRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<RoomSchedule> GetAll()
        {
            return _context.RoomSchedules.ToList();
        }

        public RoomSchedule GetById(Guid id)
        {
            var result = _context.RoomSchedules.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public RoomSchedule Create(RoomSchedule schedule)
        {
            _context.RoomSchedules.Add(schedule);
            _context.SaveChanges();
            return schedule;
        }

        public RoomSchedule Update(RoomSchedule schedule)
        {
            var updatingSchedule = _context.RoomSchedules.SingleOrDefault(a => a.Id == schedule.Id);
            if (updatingSchedule == null)
            {
                throw new NotFoundException();
            }

            updatingSchedule.Update(schedule);

            _context.SaveChanges();
            return updatingSchedule;
        }

        public void Delete(Guid scheduleId)
        {
            var schedule = GetById(scheduleId);
            _context.RoomSchedules.Remove(schedule);
            _context.SaveChanges();
        }

    }
}
