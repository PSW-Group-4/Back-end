using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.RoomsAndEqipment.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HospitalDbContext _context;       

        public RoomRepository(HospitalDbContext context)
        {
            _context = context;            
        }
        public Room Create(Room entity)
        {
            _context.Rooms.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid roomId)
        {
            var room = GetById(roomId);
            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }

        public IEnumerable<Room> GetAll()
        {
            return _context.Rooms.ToList();
        }

        public Room GetById(Guid id)
        {
            var result = _context.Rooms.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public Room Update(Room room)
        {
            var updatingRoom = _context.Rooms.SingleOrDefault(p => p.Id == room.Id);
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