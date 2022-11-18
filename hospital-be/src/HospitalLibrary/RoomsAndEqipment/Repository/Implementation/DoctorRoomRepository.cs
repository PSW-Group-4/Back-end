using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.RoomsAndEqipment.Repository.Interfaces;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.RoomsAndEqipment.Repository.Implementation
{
    public class DoctorRoomRepository : IDoctorRoomRepository
    {
        private readonly HospitalDbContext _context;

        public DoctorRoomRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public DoctorRoom Create(DoctorRoom entity)
        {
            _context.DoctorRooms.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid roomId)
        {
            var room = GetById(roomId);
            _context.DoctorRooms.Remove(room);
            _context.SaveChanges();
        }

        public IEnumerable<DoctorRoom> GetAll()
        {
            return _context.DoctorRooms.ToList();
        }

        public DoctorRoom GetById(Guid id)
        {
            var result = _context.DoctorRooms.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public DoctorRoom Update(DoctorRoom room)
        {
            var updatingRoom = _context.DoctorRooms.SingleOrDefault(p => p.Id == room.Id);
            if (updatingRoom == null)
            {
                throw new NotFoundException();
            }

            updatingRoom.Update(room);

            _context.SaveChanges();
            return updatingRoom;
        }
    }
}
