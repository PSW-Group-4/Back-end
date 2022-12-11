using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Exceptions;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.RoomsAndEqipment.Repository.Interfaces;
using HospitalLibrary.Settings;

namespace HospitalLibrary.RoomsAndEqipment.Repository.Implementation
{
    public class RoomsEquipmentRepository : IRoomsEquipment
    {
        private readonly HospitalDbContext _context;       

        public RoomsEquipmentRepository(HospitalDbContext context)
        {
            _context = context;            
        }
        public RoomsEquipment Create(RoomsEquipment entity)
        {
            _context.RoomsEquipment.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid roomId)
        {
            var room = GetById(roomId);
            _context.RoomsEquipment.Remove(room);
            _context.SaveChanges();
        }

        public IEnumerable<RoomsEquipment> GetAll()
        {
            return _context.RoomsEquipment.ToList();
        }

        public RoomsEquipment GetById(Guid id)
        {
            var result = _context.RoomsEquipment.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public RoomsEquipment Update(RoomsEquipment room)
        {
            var updatingRoom = _context.RoomsEquipment.SingleOrDefault(p => p.RoomId == room.RoomId);
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