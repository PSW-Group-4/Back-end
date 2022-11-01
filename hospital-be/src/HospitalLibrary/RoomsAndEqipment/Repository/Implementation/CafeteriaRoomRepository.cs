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
    public class CafeteriaRoomRepository : ICafeteriaRoomRepository
    {
        private readonly HospitalDbContext _context;

        public CafeteriaRoomRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public CafeteriaRoom Create(CafeteriaRoom entity)
        {
            _context.CafeteriaRooms.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            _context.CafeteriaRooms.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<CafeteriaRoom> GetAll()
        {
            return _context.CafeteriaRooms.ToList();
        }

        public CafeteriaRoom GetById(Guid id)
        {
            var result =  _context.CafeteriaRooms.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public CafeteriaRoom Update(CafeteriaRoom entity)
        {
            var updatingEntity = _context.CafeteriaRooms.SingleOrDefault(e => e.Id == entity.Id);
            if (updatingEntity == null)
            {
                throw new NotFoundException();
            }
            
            updatingEntity.Update(entity);
            
            _context.SaveChanges();
            return updatingEntity;
        }
    }
}